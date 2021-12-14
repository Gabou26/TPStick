using System.Collections;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEngine.SceneManagement;

// Script permettant d'activer et de désactiver l'arme d'un joueur,
// de distribuer une nouvelle arme ou bien de remplacer l'arme actuelle par
// une nouvelle arme ne pouvant pas être la même que la précédente.
public class ActiveWeapon : MonoBehaviour
{
    public Transform crossHairTarg;
    public Transform weaponParent;
    public Rig hankIk;
    GunWeapon rayWeapon;
    private bool pressed;
    public GunWeapon[] listWeaponsPrefab;
    private int weaponCount;
    private GunWeapon currentWeapon; // Non instancié
    private GunWeapon currentWeaponObject; // weapon clone instancié
    //Editeur
    public Transform gripLeft, gripRight;
    public Animator animator;
    AnimatorOverrideController overrides;

    //Bug Fix Aim
    public GameObject posSuiviCurseur;
    public GameObject posSuiviOrigin;
    FollowTrans posOriginWeapon;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        overrides = animator.runtimeAnimatorController as AnimatorOverrideController;
        weaponCount = listWeaponsPrefab.Length;

        StartCoroutine(DelaiEquip());
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (!rayWeapon)
        {
            hankIk.weight = 0;
            animator.SetLayerWeight(2, 0.0f);
            return;
        }

        if (pressed)
            rayWeapon.StartFiring();
        else
            rayWeapon.StopFiring();
    }

    public void OnFirePress() {
        if (SceneManager.GetActiveScene().buildIndex != 1) {
            pressed = true;
        } 
    }

    public void OnFireRelease() {
        pressed = false;
    }

    // Détruit l'objet associé à l'arme actuel  du joueur si  il possède déjà une arme et équipe
    // le joueur avec l'arme passé en paramètre issu de la méthode giveRandomWeapon()
    public void Equip(GunWeapon newWeapon)
    {
        if (rayWeapon)
            Destroy(rayWeapon.gameObject);
        rayWeapon = newWeapon;
        rayWeapon.raycastAimTarget = crossHairTarg;
        posOriginWeapon.trans = rayWeapon.rayOrigin;
        rayWeapon.rayOrigin = posOriginWeapon.transform;

        rayWeapon.transform.parent = weaponParent;
        rayWeapon.transform.localPosition = Vector3.zero;
        rayWeapon.transform.localRotation = Quaternion.identity;
        hankIk.weight = 1;
        animator.SetLayerWeight(2, 1.0f);
        Invoke(nameof(SetAnimationDelayed), 0.001f);
    }

    // Désactive l'arme pendant un état de ragdoll
    public void deactivateCurrentWeapon(){
        currentWeaponObject.gameObject.SetActive(false);
    }

    public void activateCurrentWeapon(){
        currentWeaponObject.gameObject.SetActive(true);
    }

    // Equipe le joueur avec une arme aléatoire ne pouvant pas être la même que l'arme précédente.
    public void giveRandomWeapon(){
        var randomWeaponPrefab = currentWeapon;
        do
        {
            randomWeaponPrefab = listWeaponsPrefab[Random.Range(0,weaponCount)];
        } while(randomWeaponPrefab == currentWeapon);
        currentWeapon = randomWeaponPrefab;
        GunWeapon newWeapon = Instantiate(randomWeaponPrefab);
        if (newWeapon)
            Equip(newWeapon);
        currentWeaponObject = newWeapon;
    }

    void SetAnimationDelayed()
    {
        overrides["weapon_anim_empty"] = rayWeapon.weaponAnim;
    }

    // Equipe le joueur avec une arme aléatoire en début de partie
    IEnumerator DelaiEquip()
    {
        yield return new WaitForSeconds(0.1f);
        GameObject obj = Instantiate(posSuiviCurseur);
        obj.GetComponent<FollowTrans>().trans = crossHairTarg;
        crossHairTarg = obj.transform;

        GameObject obj2 = Instantiate(posSuiviCurseur);
        posOriginWeapon = obj2.GetComponent<FollowTrans>();

        giveRandomWeapon();
    }
}

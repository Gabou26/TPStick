using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;
using UnityEditor.Animations;

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
    Animator animator;
    AnimatorOverrideController overrides;

    //Bug Fix Aim
    public GameObject posSuiviCurseur;
    public GameObject posSuiviOrigin;
    FollowTrans posOriginWeapon;

    /*private void Awake()
    {
        //Fix Bug Curseur Visee
        GameObject obj = Instantiate(posSuiviCurseur);
        obj.GetComponent<FollowTrans>().trans = crossHairTarg;
        crossHairTarg = obj.transform;

        giveRandomWeapon();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        overrides = animator.runtimeAnimatorController as AnimatorOverrideController;
        weaponCount = listWeaponsPrefab.Length;
        //giveRandomWeapon();

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
        pressed = true;
    }

    public void OnFireRelease() {
        pressed = false;
    }

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

    public void deactivateCurrentWeapon(){
        currentWeaponObject.gameObject.SetActive(false);
    }

    public void activateCurrentWeapon(){
        currentWeaponObject.gameObject.SetActive(true);
    }

    public void giveRandomWeapon(){
        var randomWeaponPrefab = currentWeapon;
        do
        {
            randomWeaponPrefab = listWeaponsPrefab[Random.Range(0,weaponCount)];
        } while(randomWeaponPrefab == currentWeapon);
        GunWeapon newWeapon = Instantiate(randomWeaponPrefab);
        if (newWeapon)
            Equip(newWeapon);
        currentWeaponObject = newWeapon;
    }

    void SetAnimationDelayed()
    {
        overrides["weapon_anim_empty"] = rayWeapon.weaponAnim;
    }

    [ContextMenu("Save Weapon Pose")]
    void SaveWeaponPose() {
        GameObjectRecorder recorder = new GameObjectRecorder(gameObject);
        recorder.BindComponentsOfType<Transform>(weaponParent.gameObject, false);
        recorder.BindComponentsOfType<Transform>(gripLeft.gameObject, false);
        recorder.BindComponentsOfType<Transform>(gripRight.gameObject, false);
        recorder.TakeSnapshot(0);
        recorder.SaveToClip(rayWeapon.weaponAnim);
        UnityEditor.AssetDatabase.SaveAssets();
    }

    IEnumerator DelaiEquip()
    {
        yield return new WaitForSeconds(0.1f);
        //Fix Bug Curseur Visee
        GameObject obj = Instantiate(posSuiviCurseur);
        obj.GetComponent<FollowTrans>().trans = crossHairTarg;
        crossHairTarg = obj.transform;

        //Fix Bug Origin Visee
        GameObject obj2 = Instantiate(posSuiviCurseur);
        //obj.GetComponent<FollowTrans>().trans = crossHairTarg;
        posOriginWeapon = obj2.GetComponent<FollowTrans>();

        giveRandomWeapon();
    }
}

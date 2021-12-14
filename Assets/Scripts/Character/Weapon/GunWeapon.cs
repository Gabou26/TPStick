using UnityEngine;

// Paramètre de l'arme: Damage et intervalle de tir défini dans le prefab de l'arme.
public class GunWeapon : MonoBehaviour
{
    protected GameObject player;
    public bool isFiring = false;
    public ParticleSystem flashTir;
    public Transform rayOrigin;
    public Transform raycastAimTarget;
    public AnimationClip weaponAnim;

    //Attributs d'arme
    public float weaponDamage = 12;
    public float interTir = 0.3f;

    //Intervalle
    float interCour = 0;

    private void Start()
    {
        player = transform.parent.gameObject;
        interCour = interTir;
    }

    public void StartFiring()
    {
        if (interCour < interTir)
        {
            StopFiring();
            return;
        }

        interCour -= interTir;
        isFiring = true;
        flashTir.Emit(1);
        Shoot();
    }

    private void Update()
    {
        if (interCour >= interTir)
            return;
        interCour += Time.deltaTime;
        if (interCour > interTir)
            interCour = interTir;
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    protected virtual void Shoot() { }
}

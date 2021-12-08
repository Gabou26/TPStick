using UnityEngine;

public class RayWeapon : GunWeapon
{
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;

    //Attributs d'arme
    public float distTir = 1000;

    //Raycast of Weapon
    Ray ray;
    RaycastHit hit;

    protected override void Shoot()
    {
        //raycastAimTarget.position = rayOrigin.position + new Vector3(0, 0, 20);
        ray.origin = rayOrigin.position;
        //ray.origin = new Vector3(0,0,5);
        ray.direction = (raycastAimTarget.position - ray.origin).normalized;

        // print(ray.direction + " | " + raycastAimTarget.position + " | " + rayOrigin.position);

        TrailRenderer tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);
        if (Physics.Raycast(ray, out hit, distTir))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.yellow, 1.0f);
            if (hit.transform.gameObject.layer == 3)
            {
                hit.transform.GetComponentInParent<ScoreManager>().SetLastShooter(player);
                HealthBar bar = hit.transform.GetComponent<HealthBar>();
                Third_person_mvmnt hitplayer = bar.gameObject.GetComponent<Third_person_mvmnt>();
                if(hitplayer.dead)
                {
                    Rigidbody point = hitplayer.spine.GetComponent<Rigidbody>();
                    if (point != null)
                    {
                        point.AddForce(player.transform.forward * 20 * weaponDamage + new Vector3(0,-100,0), ForceMode.Impulse);
                    }
                }
                else
                {
                    if (player.activeSelf && bar)
                    {
                        bar.TakeDamage(player, weaponDamage);
                    }
                }
            }


            hitEffect.transform.position = hit.point;
            hitEffect.transform.forward = hit.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hit.point;
            GetComponent<AudioSource>().Play();
        }
        else
            tracer.transform.position = ray.origin + (ray.direction * 30);
    }
}

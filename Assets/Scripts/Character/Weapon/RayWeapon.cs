using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

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
        ray.origin = rayOrigin.position;
        ray.direction = (raycastAimTarget.position - rayOrigin.position).normalized;

        TrailRenderer tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        tracer.AddPosition(ray.origin);
        if (Physics.Raycast(ray, out hit, distTir))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.yellow, 1.0f);
            if (hit.transform.gameObject.layer == 3)
            {
                hit.transform.GetComponentInParent<ScoreManager>().SetLastShooter(player);
                HealthBar bar = hit.transform.GetComponent<HealthBar>();
                if (player.activeSelf && bar)
                {
                    bar.TakeDamage(player, weaponDamage);
                }
            }


            hitEffect.transform.position = hit.point;
            hitEffect.transform.forward = hit.normal;
            hitEffect.Emit(1);

            tracer.transform.position = hit.point;
        }
        else
            tracer.transform.position = ray.origin + (ray.direction * 30);
    }
}

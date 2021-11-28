using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWeapon : GunWeapon
{
    public GameObject bulletPrefab;


    protected override void Shoot()
    {
        Vector3 bulletPos = rayOrigin.position;
        Vector3 bulletDir = (raycastAimTarget.position - rayOrigin.position).normalized;

        Transform bullet = Instantiate(bulletPrefab).transform;
        bullet.position = bulletPos;
        bullet.rotation = Quaternion.LookRotation(bulletDir, Vector3.up);
        bullet.GetComponent<BaseBullet>().weaponDamage = weaponDamage;
    }
}
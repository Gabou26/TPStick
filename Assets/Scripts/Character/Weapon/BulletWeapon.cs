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

        BaseBullet bullet = Instantiate(bulletPrefab).GetComponent<BaseBullet>();
        bullet.transform.position = bulletPos;
        bullet.transform.rotation = Quaternion.LookRotation(bulletDir, Vector3.up);
        bullet.weaponDamage = weaponDamage;
        bullet.player = player;
    }
}
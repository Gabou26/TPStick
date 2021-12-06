using UnityEngine;

public class BulletWeapon : GunWeapon
{
    public GameObject bulletPrefab;
    public Transform tempTrans;

    protected override void Shoot()
    {
        Vector3 bulletPos = rayOrigin.position;
        //Vector3 bulletPos = tempTrans.position;
        Vector3 bulletDir = (raycastAimTarget.position - rayOrigin.position).normalized;
        //Vector3 bulletDir = tempTrans.forward;

        BaseBullet bullet = Instantiate(bulletPrefab).GetComponent<BaseBullet>();
        bullet.transform.position = bulletPos;
        bullet.transform.LookAt(bulletDir + bulletPos);
        bullet.weaponDamage = weaponDamage;
        bullet.player = player;

        GetComponent<AudioSource>().Play();
    }
}
using UnityEngine;
// Direction des balles liée au arme avec l'activation de leur animation propre ainsi que de son effet sonore associé
public class BulletWeapon : GunWeapon
{
    public GameObject bulletPrefab;
    public Transform tempTrans;

    protected override void Shoot()
    {
        Vector3 bulletPos = rayOrigin.position;
        Vector3 bulletDir = (raycastAimTarget.position - rayOrigin.position).normalized;

        BaseBullet bullet = Instantiate(bulletPrefab).GetComponent<BaseBullet>();
        bullet.transform.position = bulletPos;
        bullet.transform.LookAt(bulletDir + bulletPos);
        bullet.weaponDamage = weaponDamage;
        bullet.player = player;

        GetComponent<AudioSource>().Play();
    }
}
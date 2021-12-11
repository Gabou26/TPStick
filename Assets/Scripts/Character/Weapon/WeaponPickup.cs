using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GunWeapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeW = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeW)
        {
            GunWeapon weapon = Instantiate(weaponPrefab);
            activeW.Equip(weapon);
        }

        HealthBar hb = other.GetComponent<HealthBar>();
        hb.ResetHealth();
    }
}

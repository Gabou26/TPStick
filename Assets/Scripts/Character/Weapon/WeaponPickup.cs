using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public RayWeapon weaponPrefab;

    private void OnTriggerEnter(Collider other)
    {
        ActiveWeapon activeW = other.gameObject.GetComponent<ActiveWeapon>();
        if (activeW)
        {
            RayWeapon weapon = Instantiate(weaponPrefab);
            activeW.Equip(weapon);
        }
    }
}

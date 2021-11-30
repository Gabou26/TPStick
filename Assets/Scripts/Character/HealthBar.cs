using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int[] maxHealth = new int[4] { 100, 80, 60, 40 };
    public UIHealth healthBar;

    private int reviveIndex = 0;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    public void TakeDamage(GameObject killer, float damage)
    {
        print("OUCH  : " + currentHealth);
        //GameObject playerHit = this.gameObject;
        var armorFactor = GetComponent<MysteryBoxScript>().getArmorPowerFactor();
        var attackFactor = killer.GetComponentInParent<MysteryBoxScript>().getAttackPowerFactor();
        damage /= armorFactor;  // On divise les dégats par l'armure du joueur touché
        damage *= attackFactor;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Death(killer);
        }

        if (healthBar)
            healthBar.SetHealth(currentHealth);
    }

    public virtual void Death(GameObject killer)
    {
        print("DEATH");
        GetComponent<Third_person_mvmnt>().Ragdoll();
        GetComponent<activePowerImage>().resetAllSprite();
    }

    public void Recover(int iteration)
    {
        currentHealth = maxHealth[reviveIndex];
        if (healthBar)
            healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth[reviveIndex];

        if (healthBar)
            healthBar.SetMaxHealth(maxHealth[reviveIndex], currentHealth);
    }

    public float getCurrentHealth()
    {
        return currentHealth;
    }

    public int getReviveIndex()
    {
        return reviveIndex;
    }

    public int getMaxHealth()
    {
        return maxHealth[reviveIndex];
    }

    public UIHealth getUIHealth()
    {
        return healthBar;
    }
}

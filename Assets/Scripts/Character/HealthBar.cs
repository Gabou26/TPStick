using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int[] maxHealth = new int[4] { 100, 80, 60, 40 };
    public UIHealth healthBar;

    private int reviveIndex = 0;
    private float currentHealth;

    //Flash Blanc
    Material mat;
    Color coulMat;
    float delaiCour = 1;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
        mat = GetComponentInChildren<SkinnedMeshRenderer>().material;
        coulMat = mat.color;
    }

    //Gestion Flash Lorsque Hit
    private void Update()
    {
        if (delaiCour >= 1)
            return;
        delaiCour += Time.deltaTime * 4;

        if (delaiCour > 1)
            delaiCour = 1;

        Color coul = Color.Lerp(Color.white, coulMat, delaiCour);
        mat.color = coul;
    }

    public void TakeDamage(GameObject killer, float damage)
    {
        //print("OUCH  : " + currentHealth);
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

        //Flash Blanc
        delaiCour = 0;
    }

    public virtual void Death(GameObject killer)
    {
        if(!GetComponent<Third_person_mvmnt>().dead) 
        {
            GetComponent<Third_person_mvmnt>().OnRagdoll();
            GetComponent<activePowerImage>().resetAllSprite();
        }
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

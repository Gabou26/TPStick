using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int[] maxHealth = new int[4] { 100, 80, 60, 40 };
    public UIHealthBar healthBar;

    private int reviveIndex = 0;
    private float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        ResetHealth();
    }

    public void Recover(int iteration)
    {
        currentHealth = maxHealth[reviveIndex];
        healthBar.SetHealth(currentHealth);
    }

    public void ResetHealth()
    {
        currentHealth = maxHealth[reviveIndex];
        healthBar.SetMaxHealth(maxHealth[reviveIndex], currentHealth);
    }
}

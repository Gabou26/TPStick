using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealthBar : MonoBehaviour
{
    private Slider slider;
    private Color fullHealthColor = new Color(0.16f, 0.6f, 0.25f);
    private Color lowHealthColor = new Color(0.67f, 0.24f, 0.21f);
    private GameObject fillBar;

    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
    }

    public void SetMaxHealth(int maxHealth, float health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
    }

    public void SetHealth(float health)
    {
        //slider.value = health;
        //fillBar.GetComponent<Image>().color = Color.Lerp(lowHealthColor, fullHealthColor, slider.value / slider.maxValue);
    }
}

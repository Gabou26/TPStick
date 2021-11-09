using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHealth : MonoBehaviour
{
    private Slider slider;
    private Color fullHealthColor = new Color(0.33f, 1f, 0.25f);
    private Color lowHealthColor = new Color(1f, 0.24f, 0.33f);
    public GameObject fillBar;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int maxHealth, float health)
    {
        slider.maxValue = maxHealth;
        slider.value = health;
        fillBar.GetComponent<Image>().color = Color.Lerp(lowHealthColor, fullHealthColor, slider.value / slider.maxValue);
    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fillBar.GetComponent<Image>().color = Color.Lerp(lowHealthColor, fullHealthColor, slider.value / slider.maxValue);
    }
}

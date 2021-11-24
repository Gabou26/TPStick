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
    public Text playerName;
    private UIHealth[] listUIHealth;
    private void Start()
    {
        var nbPlayer = 0;
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects){
            if(go.name == "PlayerName"){
                nbPlayer += 1;
            }
        }
        playerName.text = "Player "+nbPlayer;
    }
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


using UnityEngine;
using UnityEngine.UI;

// Script gérant l'affichage de la barre de vie du joueur qui se trouve en bas au centre de son écran.
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

    public void setPlayerName(string name){
        playerName.text = name;
    }

    public string getPlayerName(){
        return playerName.text;
    }
}

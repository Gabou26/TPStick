using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class activePowerImage : MonoBehaviour
{
    public Image speedImage;
    public Image armorImage;
    public Image attackImage;
    public Image healthImage;
    public Image changeGunImage;
    public Sprite[] spritePowerList;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void ChangeSpriteSpeed(string motCle)
    {
        if(motCle == "Down") speedImage.sprite = spritePowerList[1];
        if(motCle == "Up") speedImage.sprite = spritePowerList[2];
        if(motCle == "reset") speedImage.sprite = spritePowerList[0];
    }
    public void ChangeSpriteArmor(string motCle)
    {
        if(motCle == "Down") armorImage.sprite = spritePowerList[3];
        if(motCle == "Up") armorImage.sprite = spritePowerList[4];
        if(motCle == "reset") armorImage.sprite = spritePowerList[0]; 
    }
    public void ChangeSpriteAttack(string motCle)
    {
        if(motCle == "Down") attackImage.sprite = spritePowerList[5];
        if(motCle == "Up") attackImage.sprite = spritePowerList[6];
        if(motCle == "reset") attackImage.sprite = spritePowerList[0];
    }
    public void ChangeSpriteHealth(string motCle)
    {
        if(motCle == "Down") healthImage.sprite = spritePowerList[7];
        if(motCle == "Up") healthImage.sprite = spritePowerList[8];
        if(motCle == "reset") healthImage.sprite = spritePowerList[0];
    }

    public void ChangeSpriteGun(string motCle)
    {
        if(motCle == "Activate") changeGunImage.sprite = spritePowerList[9];
        if(motCle == "reset") changeGunImage.sprite = spritePowerList[0];
    }
    private IEnumerator waitTime(float time){
        yield return new WaitForSeconds(time);
    }
    public void resetAllSprite()
    {
        waitTime(2);
        armorImage.sprite = spritePowerList[0];
        speedImage.sprite = spritePowerList[0];
        attackImage.sprite = spritePowerList[0]; 
        changeGunImage.sprite = spritePowerList[0]; 
    }
}

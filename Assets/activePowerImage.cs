using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class activePowerImage : MonoBehaviour
{
    public Image speedImages;
    public Image armorImages;
    public Image attackImages;
    public Sprite[] spritePowerList;


    // Start is called before the first frame update
    void Start()
    {
        
        //Invoke("ChangeSprite", 10f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ChangeSpriteAttack(string motCle)
    {
        if(motCle == "Up") attackImages.sprite = spritePowerList[0];
        if(motCle == "Down") attackImages.sprite = spritePowerList[1];
        if(motCle == "reset") attackImages.sprite = spritePowerList[2];
    }
    public void ChangeSpriteSpeed(string motCle)
    {
        if(motCle == "Up") speedImages.sprite = spritePowerList[0];
        if(motCle == "Down") speedImages.sprite = spritePowerList[1];
        if(motCle == "reset") speedImages.sprite = spritePowerList[2];
    }
    public void ChangeSpriteArmor(string motCle)
    {
        if(motCle == "Up") armorImages.sprite = spritePowerList[0];
        if(motCle == "Down") armorImages.sprite = spritePowerList[1];
        if(motCle == "reset") armorImages.sprite = spritePowerList[2]; 
    }
}

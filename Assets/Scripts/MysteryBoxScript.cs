using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;


public class MysteryBoxScript : MonoBehaviour
{
    private bool hasPower;
    private float speedPowerFactor;
    private float armorPowerFactor = 1;
    private float attackPowerFactor = 1;
    private float powerUpSpeedTimer; // Timer depuis la dernière activation d'un pouvoir lié à la vitesse
    private float powerUpArmorTimer;
    private float powerUpAttackTimer;
    private float powerUpEffectTime; // Temps d'effet d'un pouvoir
    private void Start()
    {
        initialisePlayerProperties();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPower == true){
            powerUpSpeedTimer += Time.deltaTime;
            powerUpArmorTimer += Time.deltaTime;
            powerUpAttackTimer += Time.deltaTime;
            if(powerUpSpeedTimer > powerUpEffectTime){
                resetSpeedPower();
            }
            if(powerUpArmorTimer > powerUpEffectTime){
                resetArmorPower();
            }
            if(powerUpAttackTimer > powerUpEffectTime){
                resetAttackPower();
            }
        }

    }

    public float getAttackPowerFactor(){
        return attackPowerFactor;
    }
    public float getArmorPowerFactor(){
        return armorPowerFactor;
    }
    public float getSpeedPowerFactor(){
        return speedPowerFactor;
    }

    public void setArmorPowerFactor(float armorFactor){
        armorPowerFactor = armorFactor;
    }

    public void setAttackPowerFactor(float attackFactor){
        attackPowerFactor = attackFactor;
    }

    public void setSpeedPowerFactor(float speedFactor){
        speedPowerFactor = speedFactor;
    }
    public void resetSpeedPower(){
        setSpeedPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteSpeed("reset");
    }
    public void resetArmorPower(){
        setArmorPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteArmor("reset");
    }
    public void resetAttackPower(){
        setAttackPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteAttack("reset");
    }

    public void resetHealthPower(){
        GetComponent<activePowerImage>().ChangeSpriteHealth("reset");
    }

    public void activePower(string powerName){
        UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
        var maxHealth = GetComponent<HealthBar>().getMaxHealth();
        var currentHealth = GetComponent<HealthBar>().getCurrentHealth();
        hasPower = true;
        powerUpEffectTime = 10f; // Temps d'effet d'un pouvoir
        print(powerName);
        switch (powerName){
            case "SpeedUp":
            {   
                setSpeedPowerFactor(2f);
                powerUpSpeedTimer = 0;
                //Invoke("resetSpeedPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Up");
                break;
            }
            case "SpeedDown":
            {   
                setSpeedPowerFactor(0.5f);
                powerUpSpeedTimer = 0;
                //Invoke("resetSpeedPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Down");
                break;
            }
            case "ArmorUp":
            {   
                setArmorPowerFactor(2f);
                powerUpArmorTimer = 0;
                //Invoke("resetArmorPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteArmor("Up");
                break;
            }
            case "ArmorDown":
            {   
                setArmorPowerFactor(0.5f);
                powerUpArmorTimer = 0;
                //Invoke("resetArmorPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteArmor("Down");
                break;
            }
            case "AttackUp":
            {   
                setAttackPowerFactor(2f);
                powerUpAttackTimer = 0;
                //Invoke("resetAttackPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteAttack("Up");
                break;
            }
            case "AttackDown":
            {   
                setAttackPowerFactor(0.5f);
                powerUpAttackTimer = 0;
                //Invoke("resetAttackPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteAttack("Down");
                break;
            }
            case "HealthUp":
            {   
                GetComponent<activePowerImage>().ChangeSpriteHealth("Up");
                healthBar.SetHealth(maxHealth);
                Invoke("resetHealthPower", 2f);
                break;
            }
            case "HealthDown":
            {   
                GetComponent<activePowerImage>().ChangeSpriteHealth("Down");
                healthBar.SetHealth(currentHealth*2/3); // Ne fait pas trop de dégats pour le moment
                Invoke("resetHealthPower", 2f);
                break;
            }
            case "ChangeGuns":
            {   
                speedPowerFactor = 0.2f;
                //GetComponent<activePowerImage>().ChangeSprite(Color.blue);
                break;
            }
            case "BoomBoom": // Créer une pluie de bombe dans le niveau
            {   
                break;
            }
            default: break;
            
        }
    }
    public void initialisePlayerProperties(){
        hasPower = false;
        setSpeedPowerFactor(1f);
        setArmorPowerFactor(1f);
        setAttackPowerFactor(1f);
        GetComponent<activePowerImage>().resetAllSprite();
    }
}

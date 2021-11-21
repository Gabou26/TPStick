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
    private float powerUpTimer;
    private float powerUpEffectTime;
    private void Start()
    {
        initialisePlayerProperties();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasPower == true){
            powerUpTimer += Time.deltaTime;
            if(powerUpTimer > powerUpEffectTime){
                initialisePlayerProperties();
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

    public void resetArmorPower(){
        setArmorPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteArmor("reset");
    }
    public void resetAttackPower(){
        setAttackPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteAttack("reset");
    }

    public void resetSpeedPower(){
        setSpeedPowerFactor(1f);
        GetComponent<activePowerImage>().ChangeSpriteSpeed("reset");
    }

    public void activePower(string powerName){
        UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
        var maxHealth = GetComponent<HealthBar>().getMaxHealth();
        var currentHealth = GetComponent<HealthBar>().getCurrentHealth();
        powerUpTimer = 0;
        hasPower = true;
        powerUpEffectTime = 10f; // A choisir si l'onn souhaite accumuler le temps des effets (+=) ou bien le réinitialiser (=)
        print(powerName);
        switch (powerName){
            case "SpeedUp":
            {   
                setSpeedPowerFactor(2f);
                Invoke("resetSpeedPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Up");
                break;
            }
            case "SpeedDown":
            {   
                setSpeedPowerFactor(0.5f);
                Invoke("resetSpeedPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Down");
                break;
            }
            case "ArmorUp":
            {   
                setArmorPowerFactor(2f);
                Invoke("resetArmorPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteArmor("Up");
                break;
            }
            case "ArmorDown":
            {   
                setArmorPowerFactor(0.5f);
                Invoke("resetArmorPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteArmor("Down");
                break;
            }
            case "AttackUp":
            {   
                setAttackPowerFactor(2f);
                Invoke("resetAttackPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteAttack("Up");
                break;
            }
            case "AttackDown":
            {   
                setAttackPowerFactor(0.5f);
                Invoke("resetAttackPower", powerUpEffectTime);
                GetComponent<activePowerImage>().ChangeSpriteAttack("Down");
                break;
            }
            case "HealthUp":
            {   
                healthBar.SetHealth(maxHealth);
                break;
            }
            case "HealthDown":
            {   
                healthBar.SetHealth(currentHealth*2/3); // Ne fait pas trop de dégats pour le moment
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
        print("Attack" + attackPowerFactor);
        print("Armor" + armorPowerFactor);
        print("Speed" + speedPowerFactor);
    }
    public void initialisePlayerProperties(){
        hasPower = false;
        setSpeedPowerFactor(1f);
        setArmorPowerFactor(1f);
        setAttackPowerFactor(1f);
    }
}

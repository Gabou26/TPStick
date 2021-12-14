using System.Collections;
using UnityEngine;

// Script permettant de gérer tous les effets possible des boîtes mystère.
// Il est possible d'activer plusieurs pouvoir à la fois
public class MysteryBoxScript : MonoBehaviour
{
    private bool hasPower;
    private float speedPowerFactor;
    private float armorPowerFactor = 1;
    private float attackPowerFactor = 1;
    private float powerUpSpeedTimer; // Timer depuis la dernière activation d'un pouvoir lié à la vitesse
    private float powerUpArmorTimer;
    private float powerUpAttackTimer;
    private float powerUpHealthTimer;
    private float powerUpChangeGunTimer;
    private float powerUpEffectTime; // Temps d'effet d'un pouvoir
    private float powerUpHealthEffectTime; // Temps d'effet d'un pouvoir
    private float powerUpChangeGunEffectTime; // Temps d'effet d'un pouvoir

    private void Start()
    {
        initialisePlayerProperties();
    }

    // Supprime les effets d'un pouvoir si son temps d'activité est suprèrieur au temps défini pour ce pouvoir
    void Update()
    {
        if (hasPower == true){
            powerUpSpeedTimer += Time.deltaTime;
            powerUpArmorTimer += Time.deltaTime;
            powerUpAttackTimer += Time.deltaTime;
            powerUpHealthTimer += Time.deltaTime;
            powerUpChangeGunTimer += Time.deltaTime;
            if(powerUpSpeedTimer > powerUpEffectTime){
                resetSpeedPower();
            }
            if(powerUpArmorTimer > powerUpEffectTime){
                resetArmorPower();
            }
            if(powerUpAttackTimer > powerUpEffectTime){
                resetAttackPower();
            }
            if(powerUpHealthTimer > powerUpHealthEffectTime){
                resetHealthPower();
            }
            if(powerUpChangeGunTimer > powerUpChangeGunEffectTime){
                resetChangeGunPower();
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

    public void resetChangeGunPower(){
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects){
            if(go.name == "Player(Clone)"){
                go.GetComponent<activePowerImage>().ChangeSpriteGun("reset");
            }
        }
    }

    private IEnumerator waitTime(float time){
        yield return new WaitForSeconds(time);
    }
    public void activePower(string powerName){
        UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
        var maxHealth = GetComponent<HealthBar>().getMaxHealth();
        var currentHealth = GetComponent<HealthBar>().getCurrentHealth();
        hasPower = true;
        powerUpEffectTime = 10f; // Temps d'effet d'un pouvoir
        powerUpHealthEffectTime = 2f;
        powerUpChangeGunEffectTime = 4f;
        print(powerName);
        switch (powerName){
            case "SpeedUp": // Augmente le facteur de vitesse du joueur
            {   
                setSpeedPowerFactor(2f);
                powerUpSpeedTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Up");
                break;
            }
            case "SpeedDown": // Diminue le facteur de vitesse du joueur
            {   
                setSpeedPowerFactor(0.5f);
                powerUpSpeedTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteSpeed("Down");
                break;
            }
            case "ArmorUp": // Augmente le facteur d'armure du joueur
            {   
                setArmorPowerFactor(2f);
                powerUpArmorTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteArmor("Up");
                break;
            }
            case "ArmorDown": // Diminue le facteur d'armure du joueur
            {   
                setArmorPowerFactor(0.5f);
                powerUpArmorTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteArmor("Down");
                break;
            }
            case "AttackUp": // Augment le facteur d'attaque du joueur
            {   
                setAttackPowerFactor(2f);
                powerUpAttackTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteAttack("Up");
                break;
            }
            case "AttackDown": // Diminue le facteur d'attaque du joueur
            {   
                setAttackPowerFactor(0.5f);
                powerUpAttackTimer = 0;
                GetComponent<activePowerImage>().ChangeSpriteAttack("Down");
                break;
            }
            case "HealthUp": // Redonne de la vie au joueur
            {   
                GetComponent<activePowerImage>().ChangeSpriteHealth("Up");
                healthBar.SetHealth(maxHealth);
                powerUpHealthTimer = 0;
                break;
            }
            case "HealthDown": // Petite explosion sur le joueur
            {   
                GetComponent<activePowerImage>().ChangeSpriteHealth("Down");
                healthBar.SetHealth(currentHealth*2/3); // Ne fait pas trop de dégats pour le moment
                powerUpHealthTimer = 0;
                break;
            }
            case "ChangeGuns": // Change les armes de tous les joueurs
            {   
                changeAllWeapons();
                powerUpChangeGunTimer = 0;
                break;
            }
            case "BoomBoom": // Créer une pluie de bombe dans le niveau / A VENIR
            {   
                break;
            }
            default: break;
            
        }
    }

    // Méthode permettant de distribuer une nouvelle arme à chaque joueur.
    // aléatoire intelligent: Un même  joueur ne peut pas avoir la même arme 2 fois d'affilé
    private void changeAllWeapons(){
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>() ;
        foreach(GameObject go in allObjects){
            if(go.name == "Player(Clone)"){
                go.GetComponent<activePowerImage>().ChangeSpriteGun("Activate");
                waitTime(2);
                go.GetComponent<ActiveWeapon>().giveRandomWeapon();
            }
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

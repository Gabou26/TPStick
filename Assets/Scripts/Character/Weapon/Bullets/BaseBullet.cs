
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public GameObject player;
    public float vitesse = 12;
    [HideInInspector] public float weaponDamage = 10;

    public LayerMask playerTrigger;

    //LifeLength
    protected bool isDestroying = false;
    public float lifeLength = 2f;
    protected float currLength = 0;
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SocialPlatforms.Impl;

public class Third_person_mvmnt : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private Transform respawnPoint;

    public float speed = 6f;
    public float jumpForce;
    public float gravityScale;
    public float yvelocity;
    private List<string> listMisteryPower = new List<string>(){"SpeedUp","SpeedDown","ArmorUp","ArmorDown","AttackUp","AttackDown","HealthUp","HealthDown","ChangeGuns"};
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;
    public CharacterJoint spine;
    private Animator animator;
    private CharacterController charController;
    private CapsuleCollider capsCollider;
    public bool dead;
    private bool ragdoll = false;
    TPCamController cameraController;
    public Vector3 Velocity;
    private Vector3 VelocityZero;
    Vector2 i_movement = Vector2.zero;
    bool jumped = false;
    private FixedJoint joint;
    public GameObject grappleObject;
    private Grappling grapple;
    private float timedown;

    //Test Ragdoll
    public GameObject weapon;
    Vector3 direction;
    //Paused Lorsque menu est ouvert
    [HideInInspector] public static bool paused = false;

    private void Awake()
    {
        VelocityZero = new Vector3(0,0,0);
        Velocity = VelocityZero;
        respawnPoint = GameObject.Find("RespawnCube").transform; // Peut être changer ça car trop sale
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        capsCollider = GetComponent<CapsuleCollider>();
        cameraController = cam.GetComponent<TPCamController>();
        GetComponent<MysteryBoxScript>().initialisePlayerProperties();
        //GetComponent<ActiveWeapon>().restorePreviousWeapon();
        dead = false;
        grapple = grappleObject.GetComponent<Grappling>();
        timedown = 2f;
        /*
        if (weapon)
            weapon.SetActive(!dead);
        */
    }

    // public void Ragdoll()
    // {
    //    dead = !dead;
    //    charController.enabled = !charController.enabled;
    //    capsCollider.isTrigger = !capsCollider.isTrigger;
    //    animator.enabled = !animator.enabled;
    //    GetComponent<MysteryBoxScript>().initialisePlayerProperties();
    //    GetComponent<ActiveWeapon>().deactivateCurrentWeapon();
    //    /*
    //    if (weapon)
    //        weapon.SetActive(!dead);
    //    */
    //    cameraController.deadChar = dead;
    // }

    public void Ragdoll()
    {
        dead = !dead;
        charController.enabled = !charController.enabled;
        animator.enabled = !animator.enabled;
        GetComponent<MysteryBoxScript>().initialisePlayerProperties();
        GetComponent<ActiveWeapon>().deactivateCurrentWeapon();
        /*
        if (weapon)
            weapon.SetActive(!dead);
        */
        cameraController.deadChar = true;

        if (dead)
        {
            if (timedown < 10f) timedown++;

            Invoke("OnRagdoll", timedown);
        }
    }

    public void Unragdoll()
    {
        if (!controller.isGrounded)
        {
            Invoke("Unragdoll", 0.2f);
            return;
        }
        var maxHealth = GetComponent<HealthBar>().getMaxHealth();
        UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
        healthBar.SetHealth(maxHealth);
        GetComponent<HealthBar>().ResetHealth();
        dead = false;
        charController.enabled = true;
        capsCollider.isTrigger = false;
        animator.enabled = true;
        GetComponent<ActiveWeapon>().activateCurrentWeapon();
        /*
        if (weapon)
            weapon.SetActive(!dead);
        */
        cameraController.deadChar = false;
    }


    // Update is called once per frame
    void Update()
    {

        if (paused)
            jumped = false;

        if (ragdoll)
        {
            Ragdoll();
            cameraController.deadChar = dead;

            if (dead)
            {
                cameraController.CamFocus = cameraController.RagdollTarget;
                joint = gameObject.AddComponent<FixedJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = spine.transform.position;
                GetComponent<ActiveWeapon>().deactivateCurrentWeapon();
            }
            else
            {
                var maxHealth = GetComponent<HealthBar>().getMaxHealth();
                UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
                healthBar.SetHealth(maxHealth);
                GetComponent<HealthBar>().ResetHealth();
                Rigidbody r = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
                Destroy(joint);
                Destroy(r);
                GetComponent<ActiveWeapon>().activateCurrentWeapon();
                cameraController.CamFocus = cameraController.Target;
                gameObject.transform.position = spine.transform.position;
            }

            ragdoll = false;
        }

        if (dead)
        {
            if (joint != null) {
                joint.connectedAnchor = spine.transform.position;
            }

            //Velocity = Vector3.Lerp(Velocity, VelocityZero, 1f * Time.deltaTime);
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, spine.transform.position, 50f * Time.deltaTime);
            return;
        }
        float horizontal = i_movement.x;
        float vertical = i_movement.y;

        if (vertical > 0)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsBacking", false);
        }
        else if (vertical < 0)
        {
            animator.SetBool("IsBacking", true);
            animator.SetBool("IsRunning", false);
        }
        else
        {
            animator.SetBool("IsRunning", false);
            animator.SetBool("IsBacking", false);
        }

        if (horizontal > 0)
        {
            animator.SetBool("IsRight", true);
            animator.SetBool("IsLeft", false);
        }
        else if (horizontal < 0)
        {
            animator.SetBool("IsLeft", true);
            animator.SetBool("IsRight", false);
        }
        else
        {
            animator.SetBool("IsRight", false);
            animator.SetBool("IsLeft", false);
        }



        direction = (cam.forward * vertical) + (cam.right * horizontal); 
        direction.Normalize();
        float speedPowerFactor = GetComponent<MysteryBoxScript>().getSpeedPowerFactor();
        direction = direction * (speed*speedPowerFactor);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }


        if (controller.isGrounded)
        {
            Velocity = VelocityZero;
            if (jumped)
            {
                yvelocity = jumpForce;
            }
            else yvelocity = 0;
        }
        else
        {
            yvelocity += Physics.gravity.y * Time.deltaTime * gravityScale;
        }

        direction.y = yvelocity;
        
        //ceci enleve le jitter du saut
        transform.position += direction * Time.deltaTime;
        transform.position += Velocity;

        Velocity = Vector3.Lerp(Velocity, VelocityZero, 1f * Time.deltaTime) ;

        //controller.Move(direction * Time.deltaTime);

    }

    public void OnMove(InputValue value) {
        i_movement = value.Get<Vector2>();

        if (paused || (Mathf.Abs(i_movement.x) <= 0.2f && Mathf.Abs(i_movement.y) <= 0.2f))
        {
            i_movement = new Vector2(0, 0);
            return;
        }
    }

    public void OnMoveKey(InputValue value) {
        if (paused)
        {
            i_movement = new Vector2(0, 0);
            return;
        }

        i_movement = value.Get<Vector2>();
    }

    public void OnJumpPress(InputValue value) {
        if (paused)
            return;

        jumped = true;
    }

    public void OnJumpRelease(InputValue value) {
        jumped = false;
    }

    public void OnCameraH(InputValue value)
    {
        if (paused)
            return;
        cameraController.OnCameraH(value);
    }

    public void OnCameraCH(InputValue value)
    {
        if (paused)
            return;

        cameraController.OnCameraCH(value);
    }

    public void OnCameraV(InputValue value)
    {
        if (paused)
            return;
        cameraController.OnCameraV(value);
    }

    public void OnCameraCV(InputValue value)
    {
        if (paused)
            return;

        cameraController.OnCameraCV(value);
    }

    private void OnGrapplePress() {
        if (paused)
            return;
        grapple.OnGrapplePress();
    }

    private void OnGrappleRelease() {
        if (paused)
            return;
        grapple.OnGrappleRelease();
    }

    public void OnRagdoll() {
        ragdoll = !ragdoll;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            GetComponent<MysteryBoxScript>().initialisePlayerProperties();
            GetComponent<ActiveWeapon>().giveRandomWeapon();
            Transform location = respawnPoint.transform;
            float rangex = Random.Range(-(location.localScale.x / 2), location.localScale.x / 2);
            float rangez = Random.Range(-(location.localScale.z / 2), location.localScale.z / 2);
            Vector3 spawnPoint = new Vector3(location.position.x + rangex, location.position.y, location.position.z + rangez);
            transform.position = spawnPoint;
            ScoreManager sM = GetComponent<ScoreManager>();
            UIHealth healthBar = GetComponent<HealthBar>().getUIHealth();
            var maxHealth = GetComponent<HealthBar>().getMaxHealth();
            GetComponent<HealthBar>().ResetHealth();
            healthBar.SetHealth(maxHealth);
            timedown = 2f;
            Velocity = VelocityZero;
            direction = VelocityZero;
            Rigidbody point = spine.GetComponent<Rigidbody>();
            if (point != null)
            {
                point.velocity = Vector3.zero;
                point.angularVelocity = Vector3.zero;
            }

            if (!ragdoll){
                sM.ScoreDown(); //diminue le score du joueur qui tombe, utilisé lors d'une chute sans ragdoll
                //sM.GetLastShooter().GetComponentInParent(typeof(ScoreManager)).GetComponent<ScoreManager>().ScoreUp();
            }
            else
            {
                sM.GetLastShooter().GetComponentInParent(typeof(ScoreManager)).GetComponent<ScoreManager>().ScoreUp();//ligne pour augmenter le score du joueur qui a tiré en dernier sur la victime

            }
            
            
        }
    }
    private void stopVelocity()
    {
        yvelocity = 0;
    }


    void OnCollisionEnter(Collision collision)
    {
        if(Velocity != VelocityZero)
        {
            Velocity = VelocityZero;
            direction = VelocityZero;
        }

        if(collision.gameObject.tag == "MisteryBox"){
            Destroy(collision.gameObject);
            var nbPower = listMisteryPower.Count;
            var randomPower = listMisteryPower[Random.Range(0,nbPower)];
            GetComponent<MysteryBoxScript>().activePower(randomPower);
        }
    }

    GameObject GetDefaultWeapon()
    {
        return null;
    }
}
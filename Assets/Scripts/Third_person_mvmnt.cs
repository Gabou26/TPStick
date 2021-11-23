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

    //Test Ragdoll
    public GameObject weapon;

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
        dead = false;
        grapple = grappleObject.GetComponent<Grappling>();
        if (weapon)
            weapon.SetActive(!dead);
    }

    public void Ragdoll()
    {
        print("cocou");
        dead = !dead;
        charController.enabled = !charController.enabled;
        capsCollider.isTrigger = !capsCollider.isTrigger;
        animator.enabled = !animator.enabled;
        GetComponent<ActiveWeapon>().destroyCurrentWeapon();
        /*
        if (weapon)
            weapon.SetActive(!dead);
            */
        cameraController.deadChar = dead;
    }


    // Update is called once per frame
    void Update()
    {
        if (paused)
            jumped = false;

        //TEMP keyboard movement
        //float horizontalTEMP = Input.GetAxisRaw("Horizontal");
        //float verticalTEMP = Input.GetAxisRaw("Vertical");
        if (ragdoll)
        {
            GetComponent<MysteryBoxScript>().initialisePlayerProperties();
            charController.enabled = !charController.enabled;
            capsCollider.enabled = !capsCollider.enabled;
            animator.enabled = !animator.enabled;
            dead = !dead;
            cameraController.deadChar = dead;
            Ragdoll();

            if (dead)
            {
                cameraController.CamFocus = cameraController.RagdollTarget;
                joint = gameObject.AddComponent<FixedJoint>();
                joint.autoConfigureConnectedAnchor = false;
                joint.connectedAnchor = spine.transform.position;
            }
            else
            {
                Rigidbody r = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
                Destroy(joint);
                Destroy(r);
                cameraController.CamFocus = cameraController.Target;
                gameObject.transform.position = spine.transform.position;
            }

            ragdoll = false;
        }

        if (dead)
        {
            print(joint);
            joint.connectedAnchor = spine.transform.position;
            //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, spine.transform.position, 50f * Time.deltaTime);
            return;
        }
        float horizontal = i_movement.x;
        float vertical = i_movement.y;

        //if(vertical > 0 || verticalTEMP > 0)
        //{
        //    animator.SetBool("IsRunning", true);
        //    animator.SetBool("IsBacking", false);
        //}
        //else if(vertical < 0 || verticalTEMP < 0)
        //{
        //    animator.SetBool("IsBacking", true);
        //    animator.SetBool("IsRunning", false);
        //}
        //else
        //{
        //    animator.SetBool("IsRunning", false);
        //    animator.SetBool("IsBacking", false);
        //}

        //if (horizontal > 0 || horizontalTEMP > 0)
        //{
        //    animator.SetBool("IsRight", true);
        //    animator.SetBool("IsLeft", false);
        //}
        //else if (horizontal < 0 || horizontalTEMP < 0)
        //{
        //    animator.SetBool("IsLeft", true);
        //    animator.SetBool("IsRight", false);
        //}
        //else
        //{
        //    animator.SetBool("IsRight", false);
        //    animator.SetBool("IsLeft", false);
        //}
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



        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 direction = (cam.forward * vertical) + (cam.right * horizontal); 
        //Vector3 directionTEMP = (cam.forward * verticalTEMP) + (cam.right * horizontalTEMP); 
        direction.Normalize();
        //directionTEMP.Normalize();
        float speedPowerFactor = GetComponent<MysteryBoxScript>().getSpeedPowerFactor();
        direction = direction * (speed*speedPowerFactor);
        //directionTEMP = directionTEMP * speed;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }
        //else if (directionTEMP.magnitude >= 0.1f)
        //{
        //    float targetAngle = Mathf.Atan2(directionTEMP.x, directionTEMP.z) * Mathf.Rad2Deg;
        //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
        //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
        //}


        if (controller.isGrounded)
        {
            Velocity = VelocityZero;
            if (jumped)
            {
                yvelocity = jumpForce;
                //Invoke("stopVelocity", 0.6f);
            }
            //else if (Input.GetKey("space"))
            //{
            //    yvelocity = jumpForce;
            //    //Invoke("stopVelocity", 0.6f);
            //}
            else yvelocity = 0;
        }
        else
        {
            yvelocity += Physics.gravity.y * Time.deltaTime * gravityScale;
        }

        direction.y = yvelocity;
        //directionTEMP.y = yvelocity;
        
        //ceci enleve le jitter du saut
        transform.position += direction * Time.deltaTime;
        transform.position += Velocity;
        //transform.position += directionTEMP * Time.deltaTime;

        Velocity = Vector3.Lerp(Velocity, VelocityZero, .001f * Time.deltaTime) ;

        //controller.Move(direction * Time.deltaTime);

    }

    public void OnMove(InputValue value) {
        if (paused)
        {
            i_movement = new Vector2(0, 0);
            return;
        }


        i_movement = value.Get<Vector2>();
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

    public void OnCameraH(InputValue value) {
        if (paused)
            return;

        cameraController.OnCameraH(value);
    }

    public void OnCameraV(InputValue value) {
        if (paused)
            return;

        cameraController.OnCameraV(value);
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
            if(!ragdoll){
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
        Velocity = VelocityZero;

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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Third_person_mvmnt : MonoBehaviour
{
    public CharacterController controller;

    [SerializeField] private Transform respawnPoint;

    public float speed = 6f;
    public float jumpForce;
    public float gravityScale;
    public float yvelocity;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public List<string> listMisteryPower = new List<string>(){"SpeedUp","SpeedDown","ArmorUp","ArmorDown","AttackUp","AttackDown","ChangeGuns"};
    public Transform cam;
    private Animator animator;
    private CharacterController charController;
    private CapsuleCollider capsCollider;
    public bool dead;
    private bool hasPower;
    private float powerUpTimer;
    private float powerUpEffectTime;
    TPCamController cameraController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        capsCollider = GetComponent<CapsuleCollider>();
        cameraController = cam.GetComponent<TPCamController>();
        dead = false;
        hasPower = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if(hasPower == true){
            powerUpTimer += Time.deltaTime;
            if(powerUpTimer > powerUpEffectTime){
                initialisePlayerProperties();
            }
        }
        if (Input.GetKeyDown("left ctrl"))
        {
            charController.enabled = !charController.enabled;
            capsCollider.enabled = !capsCollider.enabled;
            animator.enabled = !animator.enabled;
            dead = !dead;
            cameraController.deadChar = dead;

            if(dead)
            {
                cameraController.CamFocus = cameraController.RagdollTarget;
            }
            else
            {
                cameraController.CamFocus = cameraController.Target;
            }
        }

        if (dead)
        {
            return;
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(vertical > 0)
        {
            animator.SetBool("IsRunning", true);
            animator.SetBool("IsBacking", false);
        }
        else if(vertical < 0)
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
        direction.Normalize();
        direction = direction * speed;
        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }


        if (controller.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                yvelocity = jumpForce;
                //Invoke("stopVelocity", 0.6f);
            }
            else yvelocity = 0;
        }
        else
        {
            yvelocity += Physics.gravity.y * Time.deltaTime * gravityScale;
        }

        direction.y = yvelocity;
        
        //ceci enl�ve le jitter du saut
        transform.position += direction * Time.deltaTime;
        //controller.Move(direction * Time.deltaTime);

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A");
        if (other.CompareTag("Respawn"))
        {
            Transform location = respawnPoint.transform;
            float rangex = Random.Range(-(location.localScale.x / 2), location.localScale.x / 2);
            float rangez = Random.Range(-(location.localScale.z / 2), location.localScale.z / 2);
            Vector3 spawnPoint = new Vector3(location.position.x + rangex, location.position.y, location.position.z + rangez);
            transform.position = spawnPoint;
        }
    }

    private void stopVelocity()
    {
        yvelocity = 0;
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "MisteryBox"){
            //initialisePlayerProperties(); // Delete all power up already in place
            Destroy(collision.gameObject);
            var nbPower = listMisteryPower.Count;
            var randomPower = listMisteryPower[Random.Range(0,nbPower)];
            activePower(randomPower);
        }
    }

    void activePower(string powerName){
        powerUpTimer = 0;
        hasPower = true;
        powerUpEffectTime = 10f; // A choisir si l'onn souhaite accumuler le temps des effets (+=) ou bien le réinitialiser (=)
        if(powerName == "SpeedUp"){
            speed = 30f;
        }
        else if(powerName == "SpeedDown"){
            speed = 20f;
        }
        else if(powerName == "SpeedDown"){
            speed = 20f;
        }
        else if(powerName == "ArmorUp"){
            speed = 20f;
        }
        else if(powerName == "ArmorDown"){
            speed = 20f;
        }
        else if(powerName == "AttackUp"){
            speed = 20f;
        }
        else if(powerName == "AttackDown"){
            speed = 20f;
        }
        else if(powerName == "changeGuns"){
            speed = 20f;
        }
        else{
            speed = 6f;
        }
    }
    void initialisePlayerProperties(){
        speed = 6f;
        hasPower = false;
    }
}
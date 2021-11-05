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

    public Transform cam;
    private Animator animator;
    private CharacterController charController;
    private CapsuleCollider capsCollider;
    public bool dead;
    TPCamController cameraController;

    private void Start()
    {
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        capsCollider = GetComponent<CapsuleCollider>();
        cameraController = cam.GetComponent<TPCamController>();
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
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
        
        //ceci enlève le jitter du saut
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
}
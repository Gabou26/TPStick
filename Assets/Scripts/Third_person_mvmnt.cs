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
    private bool dead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
        capsCollider = GetComponent<CapsuleCollider>();
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
        }

        if (dead) return;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");


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
            }
            else yvelocity = 0;
        }
        else
        {
            yvelocity += Physics.gravity.y * Time.deltaTime;
        }


        direction.y = yvelocity;
        controller.Move( direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Respawn"))
        {
            Transform location = respawnPoint.transform;
            float rangex = Random.Range(-(location.localScale.x / 2), location.localScale.x / 2);
            float rangez = Random.Range(-(location.localScale.z / 2), location.localScale.z / 2);
            Vector3 spawnPoint = new Vector3(location.position.x + rangex, location.position.y, location.position.z + rangez);
            transform.position = spawnPoint;
        }
    }
}
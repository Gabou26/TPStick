using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Third_person_mvmnt : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f;
    public float jumpForce;
    public float gravityScale;
    public float yvelocity;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    public Transform camera;
    
    

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        //Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;
        Vector3 direction = (camera.forward * vertical) + (camera.right * horizontal); 
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
            if (Input.GetButtonDown("Jump"))
            {
                yvelocity = jumpForce;
            }
        }
        else
        {
            yvelocity += Physics.gravity.y * Time.deltaTime;
        }
        

        direction.y = yvelocity;
        controller.Move( direction * Time.deltaTime);
        
    }
}

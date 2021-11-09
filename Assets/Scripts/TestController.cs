using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TestController : MonoBehaviour
{
    Vector2 i_movement;
    float moveSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 movement = new Vector3(i_movement.x, 0, i_movement.y) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);
    }

    public void OnMove(InputValue value) {
        Debug.Log("x : " + value.Get<Vector2>().x);
        Debug.Log("y : " + value.Get<Vector2>().y);
    }

    public void OnJump(InputValue value) {
        Debug.Log("Saut : " + value.isPressed);
    }

    public void OnCameraH(InputValue value) {
        Debug.Log("Horizontal : " + value.Get<float>());
    }

    public void OnCameraV(InputValue value) {
        Debug.Log("Vertical : " + value.Get<float>());
    }

}

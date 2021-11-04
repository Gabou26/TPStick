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

    private void OnMove(InputValue value)
    {
        i_movement = value.Get<Vector2>();
    }
}

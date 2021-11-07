using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTemp : MonoBehaviour
{
    public float speed = 12;

    Vector3 inputMouv = new Vector3();

    // Update is called once per frame
    void Update()
    {
        inputMouv.x = Input.GetAxisRaw("Horizontal");
        inputMouv.z = Input.GetAxisRaw("Vertical");

        transform.position += inputMouv * speed * Time.deltaTime;
    }
}

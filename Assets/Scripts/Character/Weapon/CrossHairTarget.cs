using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    public Transform crossHairTrans;
    Camera playerCam;
    Ray ray;
    RaycastHit hit;


    // Start is called before the first frame update
    void Start()
    {
        playerCam = transform.parent.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ray.origin = crossHairTrans.position;
        ray.direction = playerCam.transform.forward;
        if (Physics.Raycast(ray, out hit))
        {
            transform.position = hit.point;
        }

        //transform.position = new Vector3(5, 1, 0);
    }
}

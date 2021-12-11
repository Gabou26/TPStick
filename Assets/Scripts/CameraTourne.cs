using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTourne : MonoBehaviour
{

    public Camera cam;
    private float max = Mathf.Sqrt(2)*30f;
    private float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        cam.transform.position = new Vector3(max, 20, 0);
        cam.transform.rotation = Quaternion.Euler(35, 270, 0);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime/2;
        cam.transform.position = new Vector3(max*Mathf.Cos(time), 20, max*Mathf.Sin(time));
        cam.transform.rotation = Quaternion.Euler(35, 270-time/(2*Mathf.PI)*360, 0);
    }
}

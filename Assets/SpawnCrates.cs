using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    public Material cubeMat;
    [SerializeField] private Transform objectsSpawnZone;
    float min;
    float max;


    // Start is called before the first frame update
    void Start()
    {
        min = 1.0f;
        max = 10.0f;
        Invoke("SpawnBoxes", Random.Range(min,max));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void SpawnBoxes()
    {
        Transform location = objectsSpawnZone.transform;
        float rangex = Random.Range(-(location.localScale.x / 2), location.localScale.x / 2);
        float rangez = Random.Range(-(location.localScale.z / 2), location.localScale.z / 2);
        Vector3 spawnPoint = new Vector3(location.position.x + rangex, location.position.y, location.position.z + rangez);
        //transform.position = spawnPoint;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();


        //Change o� va spawn ce cube
        //cube.transform.position = new Vector3(0, 0.5f, 0);
        cube.transform.position = spawnPoint;


        cube.GetComponent<Renderer>().material = cubeMat;

        Destroy(cube, 20.0f);

        Invoke("SpawnBoxes", Random.Range(min,max));
    }
}

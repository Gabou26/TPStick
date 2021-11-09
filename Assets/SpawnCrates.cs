using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    public Material cubeMat;
    private Material cubeMaterial;
    private int nbMaterial;
    public List<Material> unityGameObjects = new List<Material>();
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
        nbMaterial = unityGameObjects.Count;
        cubeMaterial = unityGameObjects[Random.Range(0,nbMaterial)];
        cube.GetComponent<Renderer>().material = cubeMaterial;
        cube.GetComponent<Rigidbody>().mass = 10000.0f;
        cube.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(cube, 20.0f);
        //StartCoroutine(ChangeMaterial(cube,0.1));
        //Invoke("ChangeMaterial", 0.1f);
        Invoke("SpawnBoxes", Random.Range(min,max));
    }

    void ChangeMaterial(GameObject cube,double delayTime){

    }

    void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }
    }

}

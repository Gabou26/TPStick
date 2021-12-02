using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    public Material cubeMat;
    private Material cubeMaterial;
    private int nbMaterial;
    public List<Material> materialForMisteryBoxes = new List<Material>();
    [SerializeField] private Transform objectsSpawnZone;
    float min;
    float max;
    BoxCollider cube_Collider;
    public List<string> listMisteryPower = new List<string>(){"SpeedUp","SpeedDown","ArmorUp","ArmorDown","AttackUp","AttackDown","ChangeGuns"};


    // Start is called before the first frame update
    void Start()
    {
        min = 1.0f; //Interval dans lequel une boîte tombe
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
        cube_Collider = cube.GetComponent<BoxCollider>();
        cube_Collider.size = new Vector3(1.3f, 1f, 1.3f);
        cube_Collider.center = new Vector3(0f, 0f, 0f);


        //Change o� va spawn ce cube
        //cube.transform.position = new Vector3(0, 0.5f, 0);
        cube.transform.position = spawnPoint;
        nbMaterial = materialForMisteryBoxes.Count;
        cubeMaterial = materialForMisteryBoxes[Random.Range(0,nbMaterial)];
        cube.GetComponent<Renderer>().material = cubeMaterial;
        cube.tag = "MisteryBox";
        /*
        cube.GetComponent<Rigidbody>().mass = 10000.0f;
        cube.GetComponent<Rigidbody>().isKinematic = false;
        Collider collider = cube.GetComponent<BoxCollider>();
        collider.enabled = true;
        */
        Destroy(cube, 20.0f);
        
        //StartCoroutine(ChangeMaterial(cube,0.1));
        //Invoke("ChangeMaterial", 0.1f);
        Invoke("SpawnBoxes", Random.Range(min,max));
    }

    void ChangeMaterial(GameObject cube,double delayTime){

    }

}

using System.Collections.Generic;
using UnityEngine;


// Permet de faire tomber des objets mystère sur la carte
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

    void SpawnBoxes()
    {
        Transform location = objectsSpawnZone.transform;
        float rangex = Random.Range(-(location.localScale.x / 2), location.localScale.x / 2);
        float rangez = Random.Range(-(location.localScale.z / 2), location.localScale.z / 2);
        Vector3 spawnPoint = new Vector3(location.position.x + rangex, location.position.y, location.position.z + rangez);

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Rigidbody gameObjectsRigidBody = cube.AddComponent<Rigidbody>();
        cube_Collider = cube.GetComponent<BoxCollider>();
        cube_Collider.size = new Vector3(1.3f, 1f, 1.3f);
        cube_Collider.center = new Vector3(0f, 0f, 0f);

        cube.transform.position = spawnPoint;
        nbMaterial = materialForMisteryBoxes.Count;
        cubeMaterial = materialForMisteryBoxes[Random.Range(0,nbMaterial)]; // On applique un matériel aléatoire à  chaque cube
        cube.GetComponent<Renderer>().material = cubeMaterial;
        cube.tag = "MisteryBox";

        Destroy(cube, 20.0f); // Au bout de 20 secondes, le cube est détruit, il faut se dépécher de les attraper.

        Invoke("SpawnBoxes", Random.Range(min,max));
    }


}

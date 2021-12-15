using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTemp : MonoBehaviour
{
    public GameObject playerPrefab;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject obj = Instantiate(playerPrefab);
        obj.transform.position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

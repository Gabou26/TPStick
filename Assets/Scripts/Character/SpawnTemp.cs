using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTemp : MonoBehaviour
{
    public GameObject playerPrefab;

    void Awake()
    {
        GameObject obj = Instantiate(playerPrefab);
        obj.transform.position = transform.position;
    }
}

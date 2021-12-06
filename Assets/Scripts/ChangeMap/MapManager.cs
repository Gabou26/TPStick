using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class MapManager : MonoBehaviour
{
    public ChangeMapTrigger map1, map2, map3, map4, map5;
    public PlayerInputManager manager;

    public void Start() {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();

    }

    void Update()
    {
        int[] counts = {map1.playerCount, map2.playerCount, map3.playerCount, map4.playerCount,  map5.playerCount};
        string[] maps = {map1.mapName, map2.mapName, map3.mapName, map4.mapName,  map5.mapName};
        int max = counts.Max();
        if (counts[max] > 0) {
            string message = maps[max] + " : " + counts[max] + "/" + manager.playerCount;
            Debug.Log(message);
        }
    }
}

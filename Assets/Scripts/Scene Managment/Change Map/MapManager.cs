using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MapManager : MonoBehaviour
{
    public ChangeMapTrigger map1, map2, map3, map4, map5;
    public PlayerInputManager manager;
    public Text countText;

    public void Start() {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();

    }

    void Update()
    {
        int[] counts = {map1.playerCount, map2.playerCount, map3.playerCount, map4.playerCount,  map5.playerCount};
        string[] maps = {map1.mapName, map2.mapName, map3.mapName, map4.mapName,  map5.mapName};
        int max = maxTab(counts);
        if (counts[max] > 0) {
            countText.text = maps[max] + " : " + counts[max] + "/" + manager.playerCount;
        } else {
            countText.text = "";
        }
    }

    private int maxTab(int[] tab) {
        int m = 0;
        for (int i=0; i<tab.Length; i++) {
            if (tab[i] > tab[m]) {
                m = i;
            }
        }
        return m;
    }
}

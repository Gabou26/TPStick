using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnLobbyLoad : MonoBehaviour
{
    
    private PlayerInputManager manager;
    private GameObject[] players;

    void Start()
    {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();
        manager.EnableJoining();

        players = GameObject.FindGameObjectsWithTag("Player");
        int len = players.Length;
        for (int i = 0; i < len; i++) {
            players[i].transform.position = new Vector3(0 , 15, 0);
        }
    }

    
    void Update()
    {
        
    }
}

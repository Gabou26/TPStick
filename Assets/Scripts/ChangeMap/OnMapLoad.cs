
using System;

using UnityEngine;
using UnityEngine.InputSystem;

// Script appelé au charment de chaque map
public class OnMapLoad : MonoBehaviour
{
    
    private PlayerInputManager manager;
    private GameObject[] players;

    void Start()
    {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();
        manager.DisableJoining();

        players = GameObject.FindGameObjectsWithTag("Player");
        int len = players.Length;
        for (int i = 0; i < len; i++) {
            float x = Convert.ToSingle(20*Math.Cos(2*Math.PI*i/len));
            float z = Convert.ToSingle(20*Math.Sin(2*Math.PI*i/len));
            players[i].transform.position = new Vector3(x , 15, z);
            players[i].GetComponent<ScoreManager>().ResetScore();
            players[i].GetComponent<HealthBar>().ResetHealth();
        }
    }

    
    void Update()
    {
        
    }
}

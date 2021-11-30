using System.Collections;
using System.Collections.Generic;
using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class OnMapLoad : MonoBehaviour
{
    
    private PlayerInputManager manager;
    private GameObject[] players;
    private TimerDisplay timer;
    private Canvas _canvas;

    void Start()
    {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();
        manager.DisableJoining();

        timer = GetComponent<TimerDisplay>();
        _canvas = timer.GetComponentInParent<Canvas>();

        players = GameObject.FindGameObjectsWithTag("Player");
        int len = players.Length;
        for (int i = 0; i < len; i++) {
            float x = Convert.ToSingle(20*Math.Cos(2*Math.PI*i/len));
            float z = Convert.ToSingle(20*Math.Sin(2*Math.PI*i/len));
            Debug.Log("Respawning player " + i + " at " + x + ", 15, " + z);
            players[i].transform.position = new Vector3(x , 15, z);
            players[i].GetComponent<ScoreManager>().ResetScore();
        }
        if (SceneManager.GetActiveScene().buildIndex == 0) //si on retourne au lobby
        {
            timer.timerText.text = "";
            Destroy(_canvas);
        }
        else
        {
            
        }
    }

    
    void Update()
    {
        
    }
}

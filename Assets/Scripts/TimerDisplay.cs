using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    public float timeLimit;

    private float _startTime;
    
    // Start is called before the first frame update
    void Start()
    {
        this._startTime = Time.time;

    }

    // Update is called once per frame
    void Update()
    {
        if (this.timeLimit <= 0)
        {
            timerText.text = "Time's Up !!!";
            //TODO: Trigger endgame event
        }
        else
        {
          this.timeLimit -= Time.deltaTime;
          
            //formatter ajouter un 0 aux dizaines lorsqu'il ne reste que des unités
          string minutes = ((int) this.timeLimit / 60).ToString();
          string seconds = Math.Round((this.timeLimit % 60), 2).ToString();  
          timerText.text = minutes + ":" + seconds;
            
        }
        

        
        
    }
}

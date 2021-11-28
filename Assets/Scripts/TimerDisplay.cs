using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    public float timeLimit;

    private float _startTime;

    private GameObject parent;

    private bool end = false;

    private void EndGame(Dictionary<GameObject, int> scoreBoard)
    {
        int bestScore;
        KeyValuePair<GameObject, int> winner = scoreBoard.First();
        foreach (KeyValuePair<GameObject, int> kv in scoreBoard)
        {
            if (kv.Value > winner.Value) winner = kv;
        }
        timerText.text = "The winner is :";
        timerText.text += $"{winner.Key.GetComponentInChildren<UIHealth>().getPlayerName()} : {winner.Value}, ";
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        this._startTime = Time.time;
        parent = GameObject.Find("Global UI");

    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (this.timeLimit <= 0)
            {
                timerText.text = "Time's Up !!!\n";
                //TODO: Trigger endgame event
                GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
                Dictionary<GameObject, int> scoreBoard = new Dictionary<GameObject, int>();
                foreach (GameObject gameObject in allObjects)
                {
                    if (gameObject.name == "Player(Clone)")
                    {
                        scoreBoard.Add(gameObject, gameObject.GetComponent<ScoreManager>().GetScore());
                    }
                }



                /* Debug: print the scoreboard
                timerText.text += "\n";
                foreach (KeyValuePair<GameObject, int> kv in scoreBoard)
                {
                    timerText.text += $"{kv.Key.GetComponentInChildren<UIHealth>().getPlayerName()} : {kv.Value}, ";
                }
                */

                //Empeche la destruction des joueurs et du timer
                DontDestroyOnLoad(parent);
                foreach (KeyValuePair<GameObject, int> kv in scoreBoard)
                {
                    DontDestroyOnLoad(kv.Key);
                }

                timerText.text = "Switched !!!";
                //SceneManager.LoadScene(5); //Debug: t�l�portation sur une sc�ne vide
                SceneManager.LoadScene(0); //t�l�portation sur le lobby
                end = true;
                EndGame(scoreBoard);



            }
            else
            {
                this.timeLimit -= Time.deltaTime;

                //formatter ajouter un 0 aux dizaines lorsqu'il ne reste que des unit�s
                string minutes = ((int) this.timeLimit / 60).ToString();
                string seconds = Math.Round((this.timeLimit % 60), 2).ToString();
                timerText.text = minutes + ":" + seconds;

            }
        }
        else
        {
            
        }




    }
}

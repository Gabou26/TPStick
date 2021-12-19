using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/* Gestion du  timer pour une partie, il est affiché en haut de l'UI global
 le temps d'une partie est une variable qui pourra facilement être modifiée à l'avenir.
 Lorsque le temps est écoulé, les joueurs sont redirigé vers le lobby et les scores de la partie apparaissent.
*/
public class TimerDisplay : MonoBehaviour
{
    public Text timerText;
    private float _timeLimit = 30; //fixe la dur�e d'une partie � 5 minutes
    private float _startTime;
    private bool _end = false;
    
    // Start is called before the first frame update
    void Start()
    {
        this._startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (!_end)
        {
            if (this._timeLimit <= 0)
            {
                timerText.text = "Time's Up !!!\n";
                timerText.text = "Switched !!!";

                /* Cette partie du code sert à retirer l'état de ragdoll de tous les joueurs avant le changement 
                de carte, car sinon l'état persiste à ce changement, et cela engendre de nombreux bugs pour le
                joueur en question. */
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                int len = players.Length;
                for (int i = 0; i < len; i++) {
                    Third_person_mvmnt player = players[i].GetComponent<Third_person_mvmnt>();
                    if (player.dead) {
                        player.UnRagdoll();
                    }
                }

                SceneManager.LoadScene(1); //teleportation sur le lobby
                _end = true;
            }
            else
            {
                this._timeLimit -= Time.deltaTime;

                //formatter ajouter un 0 aux dizaines lorsqu'il ne reste que des unit�s
                string minutes = ((int) this._timeLimit / 60).ToString();
                minutes.PadLeft(2, '0');
                string seconds = Math.Round((this._timeLimit % 60), 2).ToString();
                seconds.PadLeft(2, '0');
                timerText.text = minutes + ":" + seconds;

            }
        }
    }
}

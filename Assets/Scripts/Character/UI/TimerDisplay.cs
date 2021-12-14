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
    private float _timeLimit = 120; //fixe la dur�e d'une partie � 5 minutes

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
                SceneManager.LoadScene(1); //t�l�portation sur le lobby
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
        else
        {

        }
        




    }
}

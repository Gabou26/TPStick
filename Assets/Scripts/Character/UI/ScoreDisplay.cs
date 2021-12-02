using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour
{

    private Text _scoreText;

    private void PrintScore()
    {
        GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<GameObject>();
        Dictionary<GameObject, int> scoreBoard = new Dictionary<GameObject, int>();
        foreach (GameObject gameObject in allObjects)
        {
            if (gameObject.name == "Player(Clone)")
            {
                scoreBoard.Add(gameObject, gameObject.GetComponent<ScoreManager>().GetScore());
            }
        }
        
        KeyValuePair<GameObject, int> winner = scoreBoard.First();
        foreach (KeyValuePair<GameObject, int> kv in scoreBoard)
        {
            if (kv.Value > winner.Value) winner = kv;
        }
        _scoreText.text = "The winner is :";
        _scoreText.text += $"{winner.Key.GetComponentInChildren<UIHealth>().getPlayerName()} : {winner.Value} !\n ";
        foreach (KeyValuePair<GameObject, int> kv in scoreBoard)
        {
            if (kv.Key !=  winner.Key)
            {
                _scoreText.text += $"{kv.Key.GetComponentInChildren<UIHealth>().getPlayerName()} : {kv.Value}\n";
            }
        }
        

    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

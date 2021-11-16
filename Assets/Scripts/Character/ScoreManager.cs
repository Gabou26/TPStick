using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int _score;
    public GameObject _lastShooter;

    public void ScoreUp()
    {
        _score++;
    }
    public void ScoreDown()
    {
        _score--;
    }

    public void SetLastShooter(GameObject lastShooter)
    {
        this._lastShooter = lastShooter;
    }

    public GameObject GetLastShooter()
    {
        return this._lastShooter;
    }
    // Start is called before the first frame update
    void Start()
    {
        _score = 0;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

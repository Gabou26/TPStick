using UnityEngine;

// Gestion du score:
// Un joueur gagne un point lorsqu'il touche un joueur et que cet autre joueur tombe de la carte
// Un joueur perd un point lorsqu'il tombe de la carte sans avoir était touché par aucun joueur.
public class ScoreManager : MonoBehaviour
{
    private int _score;
    private GameObject _lastShooter = null;

    public void ResetScore()
    {
        _score = 0;
    }

    public void ScoreUp()
    {
        _score++;
    }
    public void ScoreDown()
    {
        _score--;
    }

    public int GetScore()
    {
        return _score;
    }

    public void ResetLastShooter()
    {
        SetLastShooter(null);
    }

    public void SetLastShooter(GameObject lastShooter)
    {
        _lastShooter = lastShooter;
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

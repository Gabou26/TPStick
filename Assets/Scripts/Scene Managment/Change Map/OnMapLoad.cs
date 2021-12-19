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
            players[i].transform.position = new Vector3(20*Mathf.Cos(2*Mathf.PI*i/len) , 15, 20*Mathf.Sin(2*Mathf.PI*i/len));
            players[i].GetComponent<ScoreManager>().ResetScore();
            players[i].GetComponent<HealthBar>().ResetHealth();
        }
    }
}

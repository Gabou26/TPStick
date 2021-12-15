
using UnityEngine;
using UnityEngine.InputSystem;

// Script appelé au chargement du lobby
public class OnLobbyLoad : MonoBehaviour
{
    
    private PlayerInputManager manager;
    private GameObject[] players;

    void Start()
    {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();
        manager.EnableJoining();

        players = GameObject.FindGameObjectsWithTag("Player");
        int len = players.Length;
        for (int i = 0; i < len; i++) {
            players[i].transform.position = new Vector3(0 , 15, 0);
            players[i].GetComponent<ScoreManager>().ResetScore();
            players[i].GetComponent<HealthBar>().ResetHealth();
            players[i].GetComponent<ActiveWeapon>().OnFireRelease();
            Third_person_mvmnt player = players[i].GetComponent<Third_person_mvmnt>();
        }
    }

    
    void Update()
    {
        
    }
}

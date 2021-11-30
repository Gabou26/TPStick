using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeMapTrigger : MonoBehaviour
{
    private int playerCount;
    public PlayerInputManager manager;

    public void Start() {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();
    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {

            playerCount++;
            if (playerCount > 1 && playerCount == manager.playerCount) {
                switch(this.name) {
                    case "Trigger1":
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                        break;
                    case "Trigger2":
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
                        break;
                    case "Trigger3":
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
                        break;
                    case "Trigger4":
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
                        break;
                }
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerCount--;
        }
    }
}


using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class ChangeMapTrigger : MonoBehaviour
{
    public PlayerInputManager manager;
    public string mapName;
    public int playerCount = 0;

    public void Start() {
        manager = GameObject.FindObjectOfType<PlayerInputManager>();

    }

    public void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            int i = 0;

            switch(this.name) {
                case "Trigger1":
                    i = 1;
                    break;
                case "Trigger2":
                    i = 2;
                    break;
                case "Trigger3":
                    i = 3;
                    break;
                case "Trigger4":
                    i = 4;
                    break;
                case "Trigger5":
                    i = 5;
                    break;
            }

            playerCount++;
            
            if (manager.playerCount > 1 && playerCount == manager.playerCount) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + i);
            }
        }
    }

    public void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            playerCount--;
        }
    }
}

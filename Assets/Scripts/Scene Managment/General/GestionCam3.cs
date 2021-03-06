using UnityEngine;
using UnityEngine.InputSystem;
 
// Affichage de la 4ème caméra avec une vue globale sur la carte lorsqu'il y a seulement 3 joueurs
public class GestionCam3 : MonoBehaviour
{

    public PlayerInputManager manager;
    public Camera cam3;
    private int previousNumber;

    public void OnPlayerJoined() {
        int newNumber = manager.playerCount;

        if (previousNumber == 0) {
            // Redimentionner Cam3 et Désactiver Cam3
            cam3.enabled = false;
            cam3.rect = new Rect(.5f, 0f, .5f, .5f);
        } else if (previousNumber !=3 && newNumber == 3) {
            // Activer Cam3
            cam3.enabled = true;
        } else if (previousNumber == 3 && newNumber !=3) {
            // Desactiver Cam3
            cam3.enabled = false;
        }

        previousNumber = newNumber;
    }
}

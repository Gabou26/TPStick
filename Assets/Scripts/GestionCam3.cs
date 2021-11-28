using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GestionCam3 : MonoBehaviour
{

    public PlayerInputManager manager;
    private int previousNumber;

    public void OnPlayerJoined() {
        int newNumber = manager.playerCount;
        Debug.Log("Nombre actuel : " + previousNumber + ", nouveau nombre : " + newNumber);

        if (previousNumber !=3 && newNumber == 3) {
            // Activer les carrés noirs
        } else if (previousNumber == 3 && newNumber !=3) {
            // Desactiver les carrés noirs
        }

        previousNumber = newNumber;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseInputSystem : MonoBehaviour
{
    PlayerInput input;

    private void Start()
    {
        input = transform.GetComponent<PlayerInput>();
    }

    void OnPause()
    {
        //NewPause pauseMenu = FindObjectOfType<NewPause>();
        //if (!pauseMenu.open)
        //{
        //    pauseMenu.Show(input.currentControlScheme.Equals("MouseKeyboard"));
        //}
        //else
        //{
        //    pauseMenu.Hide();
        //}
    }
}

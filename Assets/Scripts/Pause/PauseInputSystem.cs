using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class PauseInputSystem : MonoBehaviour
{
    private PlayerPauseInput input;
    private InputAction pauseTrigger;

    private NewPause pauseMenu;

    private void Awake()
    {
        input = new PlayerPauseInput();
    }

    private void Start()
    {
        CanvasPause pauseCanvas = CanvasPause.instance;
        if (pauseCanvas)
            pauseMenu = pauseCanvas.GetComponentInChildren<NewPause>();
    }

    private void OnEnable()
    {
        pauseTrigger = input.Player.Pause;
        pauseTrigger.Enable();

        input.Player.Pause.performed += PauseGame;
        input.Player.Pause.Enable();
    }

    private void PauseGame(InputAction.CallbackContext context)
    {
        if (!pauseMenu)
            return;

        //print(context.control.layout);
        if (!pauseMenu.open)
        {
            pauseMenu.Show(context.control.layout.Equals("Key"));
        }
        else
        {
            pauseMenu.Hide();
        }
    }
}

﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Gestion des différentes options du menu pause
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject[] buttons;
    [SerializeField] private TransitionUI trans;

    public void ReturnMainMenu()
    {
        Time.timeScale = 1f;
        StartCoroutine(ReturnMenu());
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void DisconnectEveryone()
    {
        ReturnMainMenu();
    }

    public void Show()
    {
        Time.timeScale = 0.001f;
        foreach (var button in buttons)
        {
            button.SetActive(true);
        }
    }

    public void Hide()
    {
        Time.timeScale = 1f;
        foreach (var button in buttons)
        {
            button.SetActive(false);
        }
    }

    IEnumerator ReturnMenu()
    {
        trans.Transition(new Vector2(0, 1200), new Vector2(0, 0), false);
        yield return new WaitForSeconds(0.6f);
        SceneManager.LoadScene(0);
        trans.Transition(new Vector2(0, 0), new Vector2(0, 1200), false);
    }
}

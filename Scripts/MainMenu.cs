using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void quitGame()
    {
        Application.Quit();
        Debug.Log("Quitting");
    }

    public void startGame()
    {
       SceneManager.LoadScene("Game");
        Debug.Log("StartGame");

    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Debug.Log("MainMenu");

    }

    public void creditsMenu()
    {
        SceneManager.LoadScene("CreditsMenu");
        Debug.Log("Credits");
    }
}

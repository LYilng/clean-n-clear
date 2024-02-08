using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("Tutorial");
        SceneManager.LoadScene("LevelSelect");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("U QUITed");
        Application.Quit();
    }

    public void Lvl1()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("Level02");
    }
}

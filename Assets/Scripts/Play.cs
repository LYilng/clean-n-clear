using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void LoadScene()
    {
        Debug.Log("Loading level 1");
        SceneManager.LoadScene("Level01");
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("U QUITed");
        Application.Quit();
    }
}

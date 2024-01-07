using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    bool isPaused = false;
    private int currentLvlID;

    void Start()
    {
        pauseMenu.SetActive(false);
        currentLvlID = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene Index: " + currentLvlID);
    }

    void Update()
    {
        if (isPaused)
        {
            PauseLevel();
        }
        else
        {
            ResumeLevel();
        }
    }

    public void PauseLevel()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeLevel()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLvlID);
    }
}
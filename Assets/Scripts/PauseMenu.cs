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
    public GameObject[] canvasElements;

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
        HideCanvasElements();
    }

    public void ResumeLevel()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        ShowCanvasElements();
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(currentLvlID);
    }

    public void HideCanvasElements()
    {
        foreach (GameObject canvasElement in canvasElements)
        {
            if (canvasElement != null)
            {
                canvasElement.SetActive(false);
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    public void ShowCanvasElements()
    {
        foreach (GameObject canvasElement in canvasElements)
        {
            if (canvasElement != null)
            {
                canvasElement.SetActive(true);
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }
}
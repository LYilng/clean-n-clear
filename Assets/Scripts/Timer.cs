using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    public static Timer instance;

    public TMP_Text timerText; // Reference to the TextMeshPro Text component
    public GameObject panel;
    public TMP_Text panelTimerText;

    private float timer;
    public bool isTiming;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        timer = 0f;
        isTiming = true;

        panel.SetActive(false);
    }

    void Update()
    {
        if (isTiming)
        {
            timer += Time.deltaTime;
            UpdateTimerText();
        }

        // Check for the "Q" key press to stop the timer
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StopTimer();
        }
    }

    void UpdateTimerText()
    {
        // Update the TMP text with the current timer value
        if (timerText != null)
        {
            timerText.text = TimeSpan.FromSeconds(timer).ToString(@"mm\:ss"); // Format to two decimal places
        }
    }

    void StopTimer()
    {
        isTiming = false;
        UpdateTimerText(); // Update one last time to ensure the final time is displayed
        Debug.Log("Timer stopped. Final time: " + timer);
    }

    public void ShowPanelWithTimer()
    {
        panel.SetActive(true); // Show the panel
        isTiming = false; // Stop the timer
        Time.timeScale = 0f; // Pause the game

        // Update the TextMeshPro on the panel with the current timer value
        if (panelTimerText != null)
        {
            panelTimerText.text = TimeSpan.FromSeconds(timer).ToString(@"mm\:ss");
        }
    }
}

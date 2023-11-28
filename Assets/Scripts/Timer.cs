using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timerText; // Reference to the TextMeshPro Text component
    private float timer;
    private bool isTiming;

    void Start()
    {
        timer = 0f;
        isTiming = true;
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
            timerText.text = timer.ToString("F2"); // Format to two decimal places
        }
    }

    void StopTimer()
    {
        isTiming = false;
        UpdateTimerText(); // Update one last time to ensure the final time is displayed
        Debug.Log("Timer stopped. Final time: " + timer);
    }
}

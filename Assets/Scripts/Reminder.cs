using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reminder : MonoBehaviour
{
    public GameObject reminderPanel;
    public GameObject[] canvasElements;
    private CameraPPV cameraPPV;

    void Start()
    {
        if(reminderPanel != null)
        {
            reminderPanel.SetActive(false);
        }
    }

    public void DisplayReminder()
    {
        if(reminderPanel != null)
        {
            reminderPanel.SetActive(true);
            cameraPPV.SwitchToCamera();
            HideCanvasElements();
        }
    }

    public void HideReminder()
    {
        if(reminderPanel != null)
        {
            reminderPanel.SetActive(false);
            cameraPPV.SwitchToGlobal();
            ShowCanvasElements();
        }
    }

    public void HideCanvasElements()
    {
        foreach(GameObject canvasElement in canvasElements)
        {
            if(canvasElement != null)
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

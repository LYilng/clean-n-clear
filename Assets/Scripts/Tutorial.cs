using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject[] panels;
    public GameObject canvasElements;
    private int currentPanelIndex = 0;

    void Start()
    {
        Timer.instance.isTiming = false;
        // Initially hide all panels except the first one
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
        if (panels.Length > 0)
        {
            panels[0].SetActive(true);
        }
    }

    public void Update()
    {
        if(currentPanelIndex == 0 || currentPanelIndex == 2 || currentPanelIndex == 3 || currentPanelIndex == 4 || currentPanelIndex == 5 || currentPanelIndex == 6 || currentPanelIndex == 8)
        {
            CameraPPV.instance.SwitchToCamera();
            HideCanvasElements();
        }

        else
        {
            CameraPPV.instance.SwitchToGlobal();
            ShowCanvasElements();
        }
    }

    public void NextPanel()
    {
        if (currentPanelIndex < panels.Length - 1)
        {
            panels[currentPanelIndex].SetActive(false);
            currentPanelIndex++;
            panels[currentPanelIndex].SetActive(true);
        }
        else
        {
            // All panels shown, maybe close the tutorial
            Debug.Log("Tutorial Finished");
        }
    }

    public void Skip()
    {
        SceneManager.LoadScene("Level01");
    }

    public void HideCanvasElements()
    {
        canvasElements.SetActive(false);
    }

    public void ShowCanvasElements()
    {
        canvasElements.SetActive(true);
    }
}

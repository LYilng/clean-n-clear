using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Tutorial : MonoBehaviour
{
    public GameObject[] panels;
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
    


}

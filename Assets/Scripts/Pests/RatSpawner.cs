using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    private float lastExecutionTime;
    public Transform pestFolder;
    private int ratIndex = 0;

    private void Update()
    {
        if (ratIndex <= 5)
        {
            // Check if 5 seconds have passed since the last execution
            if (Time.time - lastExecutionTime >= 5f && CheckRatsInScene() == true)
            {
                // Run your code here
                pestFolder.GetChild(ratIndex).gameObject.SetActive(true);
                ratIndex++;

                // Update the last execution time
                lastExecutionTime = Time.time;
            }
        }
    }

    private bool CheckRatsInScene()
    {
        int pestCount = pestFolder.childCount;

        foreach (Transform rat in pestFolder)
        {
            if (rat.gameObject.activeSelf == true)
            {
                break;
            }
            else
            {
                pestCount--;
            }
        }

        if (pestCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

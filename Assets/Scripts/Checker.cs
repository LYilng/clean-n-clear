using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checker : MonoBehaviour
{
    public string objectTag = "Object";
    public string nextSceneName = "NextScene";

    public BoxCollider groundCollider;
    private Bounds groundBounds;
    public GameObject panel;
    public Timer timer;
    public ConfirmPosition confirmPosition;

    public Transform trashFolder;
    public Transform pestFolder;

    public static bool success = true;

    public GameObject reminderPanel;
    public GameObject canvasElements;

    public int nextSceneLoad;

    void Start()
    {
        RotateArea();

        groundBounds = groundCollider.bounds;

        nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
    }

    void RotateArea()
    {
        // Rotate the area checker 90 degrees around the y-axis
        transform.Rotate(0f, 90f, 0f);
    }

    private bool CheckObjectsInArea()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objectTag);
        bool isObjInArea = true;

        foreach (GameObject obj in objectsWithTag)
        {
            BoxCollider objCollider = obj.GetComponent<BoxCollider>();
            Vector3 objPos = obj.transform.position;

            if (objCollider.size.x % 2 != 0)  //If object is 1x1 size
            {
                if (!(objPos.z > groundBounds.min.z + 3f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                {
                    isObjInArea = false;
                    break;
                }
            }

            else
            {
                if (obj.transform.eulerAngles.y == 0)
                {
                    if (!(objPos.z > groundBounds.min.z + 3f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                    {
                        isObjInArea = false;
                        break;
                    }
                }

                else
                {
                    if (!(objPos.z > groundBounds.min.z + 4f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                    {
                        isObjInArea = false;
                        break;
                    }
                }
            }
        }

        if (isObjInArea)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckTrashInArea()
    {
        int trashCount = trashFolder.childCount;

        for (int i = 0; i < trashFolder.childCount; i++)  //For every object that is a child of the 'Objects' game object,
        {
            Transform child = trashFolder.GetChild(i);

            if (child.gameObject.activeSelf == true)
            {
                break;
            }
            else
            {
                trashCount--;
            }
        }

        if (trashCount > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private bool CheckPestsInArea()
    {
        int pestCount = pestFolder.childCount;

        for (int i = 0; i < pestFolder.childCount; i++)  //For every object that is a child of the 'Objects' game object,
        {
            Transform child = pestFolder.GetChild(i);

            if (child.gameObject.activeSelf == true)
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

    public void CheckSuccess()
    {
        bool isObjsInArea = CheckObjectsInArea();
        bool containsTrash = CheckTrashInArea();
        bool containsPests = CheckPestsInArea();

        if (isObjsInArea && !containsTrash && !containsPests)  //If objects are in correct area and all trash is removed
        {
            //LoadNextScene();
            timer.ShowPanelWithTimer();
            confirmPosition.ShowPanelWithMove();

            Health.instance.HealthText();

            LevelStars.instance.MoveStarChecker();
            LevelStars.instance.TimeStarChecker();
            LevelStars.instance.HealthStarChecker();
            CameraPPV.instance.SwitchToCamera();
            HideCanvasElements();
        }
        else
        {
            Health.instance.ReduceHealth(1);

            if(Health.instance.currentHealth <= 0)
            {
                reminderPanel.SetActive(false);
            }
            else
            {
                panel.SetActive(false);
                ShowReminder();
            }
        }
    }

    public void LoadNextScene()
    {
        Debug.Log("All the objects are within the allowed area :)");
        Debug.Log("Loading Next Level");
        SceneManager.LoadScene(nextSceneLoad);

        if(nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", nextSceneLoad);
        }
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void ShowReminder()
    {
        HideCanvasElements();
        reminderPanel.SetActive(true);
        CameraPPV.instance.SwitchToCamera();
        Timer.instance.isTiming = false;
    }

    public void HideReminder()
    {
        reminderPanel.SetActive(false);
        CameraPPV.instance.SwitchToGlobal();
        Timer.instance.isTiming = true;

        canvasElements.SetActive(true);
    }

    public void HideCanvasElements()
    {
        canvasElements.SetActive(false);
    }
}
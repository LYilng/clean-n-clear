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

    private bool success = true;

    void Start()
    {
        RotateArea();

        groundBounds = groundCollider.bounds;
    }

    void RotateArea()
    {
        // Rotate the area checker 90 degrees around the y-axis
        transform.Rotate(0f, 90f, 0f);
    }

    public void CheckObjectsInArea()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objectTag);

        foreach (GameObject obj in objectsWithTag)
        {
            BoxCollider objCollider = obj.GetComponent<BoxCollider>();
            Vector3 objPos = obj.transform.position;

            if (objCollider.size.x % 2 != 0)  //If object is 1x1 size
            {
                if (!(objPos.z > groundBounds.min.z + 3f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                {
                    success = false;
                    break;
                }
            }

            else
            {
                if (obj.transform.eulerAngles.y == 0)
                {
                    if (!(objPos.z > groundBounds.min.z + 3f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                    {
                        success = false;
                        break;
                    }
                }

                else
                {
                    if (!(objPos.z > groundBounds.min.z + 4f && objPos.z < groundBounds.max.z))  //if x position is within boundaries of correct area
                    {
                        success = false;
                        break;
                    }
                }
            }
        }

        if (success)
        {
            LoadNextScene();
        }
        else
        {
            Debug.Log("Level Failed");
        }

        success = true;
    }

    void LoadNextScene()
    {
        Debug.Log("All the objects are within the allowed area :)");
        Debug.Log("Loading Next Level");
        SceneManager.LoadScene("Level02");
    }
}

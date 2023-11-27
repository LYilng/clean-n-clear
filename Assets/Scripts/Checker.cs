using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checker : MonoBehaviour
{
    public string objectTag = "Object";
    public float areaWidth = 2f;
    public float areaLength = 11f;
    public string nextSceneName = "NextScene";

    void Start()
    {
        RotateArea();
    }

    void Update()
    {
        if (CheckObjectsInArea())
        {
            LoadNextScene();
        }
    }

    void RotateArea()
    {
        // Rotate the area checker 90 degrees around the y-axis
        transform.Rotate(0f, 90f, 0f);
    }

    bool CheckObjectsInArea()
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(objectTag);

        foreach (GameObject obj in objectsWithTag)
        {
            Vector3 objPosition = obj.transform.position;

            float areaCenterX = transform.position.x;
            float areaCenterZ = transform.position.z;

            // Check if the object is within the specified area
            if (objPosition.x < areaCenterX - areaLength / 2 || objPosition.x > areaCenterX + areaLength / 2 ||
                objPosition.z < areaCenterZ - areaWidth / 2 || objPosition.z > areaCenterZ + areaWidth / 2)
            {
                // Object is outside the area
                return false;
            }
        }

        // All objects are within the area
        return true;
    }

    void LoadNextScene()
    {
        Debug.Log("DEAD");
    }
}

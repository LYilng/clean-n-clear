using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    public float gridSize = 1f;

    void Update()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Snap to the grid by rounding to the nearest gridSize
        float snappedX = Mathf.Round(currentPosition.x / gridSize) * gridSize;
        float snappedZ = Mathf.Round(currentPosition.z / gridSize) * gridSize;

        // Update the object's position
        transform.position = new Vector3(snappedX, 0f, snappedZ);
    }
}
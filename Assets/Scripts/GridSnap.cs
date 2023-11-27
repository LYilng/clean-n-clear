using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    public float gridSize = 1f;
    public int minX, maxX;
    public int minZ, maxZ;

    private float snappedX;
    private float snappedZ;

    private float clampedX;
    private float clampedZ;

    private BoxCollider objSize;
    public BoxCollider boundingCollider;

    private void Start()
    {
        objSize = GetComponent<BoxCollider>();
    }

    void Update()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Snap to the grid by rounding to the nearest gridSize
        snappedX = Mathf.Round(currentPosition.x / gridSize) * gridSize;
        snappedZ = Mathf.Round(currentPosition.z / gridSize) * gridSize;

        //clampedX = Mathf.Clamp(snappedX, minX, maxX);
        //clampedZ = Mathf.Clamp(snappedZ, minZ, maxZ);

        Bounds bounds = boundingCollider.bounds;

        if (objSize.size.x % 2 == 0)
        {
            clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 1.5f);
            clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 0.5f, bounds.max.z - 0.5f);
        }
        else
        {
            clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 0.5f, bounds.max.z - 0.5f);
        }

        // Update the object's position
        transform.position = new Vector3(clampedX, 0f, clampedZ);
    }
}
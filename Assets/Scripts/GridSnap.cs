using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSnap : MonoBehaviour
{
    public float gridSize = 1f;

    private float snappedX;
    private float snappedZ;

    private float clampedX;
    private float clampedZ;

    private BoxCollider objSize;
    public BoxCollider boundingCollider;

    private Bounds bounds;

    private bool isIntersecting;
    private Vector3 lastPlaced;

    private void Start()
    {
        objSize = GetComponent<BoxCollider>();
        bounds = boundingCollider.bounds;
    }

    void OnCollisionEnter(Collision collision)
    {
        isIntersecting = true;
        Debug.Log("is Intersecting");
    }

    void Update()
    {
        // Get the current position of the object
        Vector3 currentPosition = transform.position;

        // Snap to the grid by rounding to the nearest gridSize
        snappedX = Mathf.Round(currentPosition.x / gridSize) * gridSize;
        snappedZ = Mathf.Round(currentPosition.z / gridSize) * gridSize;

        if (objSize.size.x % 2 != 0)  //If object is 1x1 size
        {
            clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 0.5f);
            clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 0.5f, bounds.max.z - 0.5f);
        }

        else
        {
            if (transform.eulerAngles.y == 0)
            {
                /*if (objSize.size.x % 2 == 0)  //If object size is even, snap to within boundary coordinates
                {
                    clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 1.5f);
                    clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 0.5f, bounds.max.z - 0.5f);
                }*/
                clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 1.5f);
                clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 0.5f, bounds.max.z - 0.5f);
            }

            else
            {
                /*if (objSize.size.x % 2 == 0)  //If object size is even, snap to within boundary coordinates
                {
                    clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 0.5f);
                    clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 1.5f, bounds.max.z - 0.5f);
                }*/
                clampedX = Mathf.Clamp(snappedX, bounds.min.x + 0.5f, bounds.max.x - 0.5f);
                clampedZ = Mathf.Clamp(snappedZ, bounds.min.z + 1.5f, bounds.max.z - 0.5f);
            }
        }

        if (isIntersecting)
        {
            transform.position = lastPlaced;
        }
        else
        {
            //Force the object's position to be within boundaries
            transform.position = new Vector3(clampedX, 0f, clampedZ);
            lastPlaced = transform.position;
        }
    }
}
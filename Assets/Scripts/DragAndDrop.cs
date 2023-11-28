using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    [SerializeField] private LayerMask hoverAreaLayer;

    private Vector3 lastPlaced;

    void OnMouseDown()
    {
        Transform initialPos = transform;  //Save initial position

        offset = transform.position - GetMouseWorldPos();  // Calculate offset between mouse position and object position
        isDragging = true;
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;  //Set object position based on the mouse position

            // Check if "R" key is pressed
            if (Input.GetKeyDown(KeyCode.R))
            {
                RotateObject();
            }
        }
    }

    void RotateObject()
    {
        // Get the current rotation of the object
        Vector3 currentRotation = transform.eulerAngles;

        // Check if the object is already rotated to a specific angle
        if (Mathf.Approximately(currentRotation.y, 90f))
        {
            // Object is already rotated, do something else or skip rotation
            transform.Rotate(Vector3.down, 90f);
        }
        else
        {
            // Rotate the object by 90 Degrees around the Y-axis
            transform.Rotate(Vector3.up, 90f);
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hoverAreaLayer))
        {
            lastPlaced = new Vector3(hit.point.x, 0f, hit.point.z);  //Update latest position

            return lastPlaced;  // Adjust the hit point based on the isometric perspective
        }

        return lastPlaced;  //Return position before out of bounds
    }
}
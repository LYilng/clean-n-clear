using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    [SerializeField] private LayerMask groundLayer;

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
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;


        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            lastPlaced = new Vector3(hit.point.x, 0f, hit.point.z);  //Update latest position

            return lastPlaced;  // Adjust the hit point based on the isometric perspective
        }

        return lastPlaced;  //Return position before out of bounds
    }
}
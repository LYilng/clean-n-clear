using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;

    public LayerMask groundLayer;

    void OnMouseDown()
    {
        //Save initial position
        Transform initialPos = transform;

        // Calculate offset between mouse position and object position
        offset = transform.position - GetMouseWorldPos();
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
            //Set object position based on the mouse position
            transform.position = GetMouseWorldPos() + offset;
        }
    }

    Vector3 GetMouseWorldPos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            // Adjust the hit point based on the isometric perspective
            return new Vector3(hit.point.x, 0f, hit.point.z);
        }

        return Vector3.zero;
    }
}
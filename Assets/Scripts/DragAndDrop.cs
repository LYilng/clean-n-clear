using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    //public static DragAndDrop instance;

    [SerializeField] private LayerMask hoverAreaLayer;  //Layermask for mouse raycast detection

    //Dragging
    private bool isDragging = false;
    private Vector3 mousePos;  //Mouse position
    private Vector3 offset;

    //Object variables
    public int ID { get; set; }  //Object ID
    Vector3 initialPos;  //Initial Position before confirmation
    Quaternion initialRot;

    //Grid System
    private float snappedX;
    private float snappedZ;
    private float gridSize = 1f;

    //UI
    public GameObject objUI;  //Object UI (confirm, cancel, rotate)
    private Vector3 UIOffset = new Vector3(0, -200, 0);

    private void Start()
    {
        initialPos = transform.position;  //Save obj's start position
        initialRot = transform.rotation;
    }

    void OnMouseDown()
    {
        if(IDManager.instance.isObjSelected == false)  //If an object is not selected
        {
            IDManager.instance.isObjSelected = true;
            IDManager.instance.selectedID = ID;  //Store the object's ID as the selectedID

            initialPos = transform.position;  //Save initial position before confirmation
            initialRot = transform.rotation;  //Save initial rotation before confirmation
        }

        if (IDManager.instance.selectedID == ID)  //Check if the selected ID matches with the object's ID (to ensure player cannot move anything else before confirming)
        {
            ConfirmPosition.instance.OpenObjUI();  //Open confirmation UI

            offset = transform.position - GetMouseWorldPos();  // Calculate offset between mouse position and object position
            isDragging = true;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }

    void Update()
    {
        //If isDragging is true, make the object follow the mouse position
        if (isDragging)
        {
            transform.position = GetMouseWorldPos() + offset;  //Set object position based on the mouse position

            //Adjust position of UI to make it below the object (includes snapping)
            Vector3 currentPosition = transform.position;
            snappedX = Mathf.Round(currentPosition.x / gridSize) * gridSize;
            snappedZ = Mathf.Round(currentPosition.z / gridSize) * gridSize;
            objUI.transform.position = Camera.main.WorldToScreenPoint(new Vector3(snappedX, transform.position.y, snappedZ)) + UIOffset;
        }
    }

    public void RotateObject()
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
            mousePos = new Vector3(hit.point.x, 0f, hit.point.z);  //Update latest mouse position
        }

        return mousePos;  //Return mouse position
    }

    public bool CheckIntersecting()
    {
        BoxCollider boxCollider = GetComponent<BoxCollider>();  //Gets object's box collider
        Bounds colliderBounds = boxCollider.bounds;  //Gets the bounds of box collider
        Collider[] colliders = Physics.OverlapBox(colliderBounds.center, colliderBounds.extents, transform.rotation);  //Check for colliders intersecting with boundaries of object's box collider

        foreach (Collider obj in colliders)
        {
            if (obj.CompareTag("TrashBag"))
            {
                Debug.Log("Trash Bag DESTORYED an object :>");
                Destroy(boxCollider.gameObject);

                TrashBag.instance.UpdateUI();
                return false;
            }
        }
        /*
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].CompareTag("TrashBag"))
            {
                Debug.Log("Trash Bag DESTORYED an object :>");
                Destroy(obj.gameObject);

                TrashBag.instance.UpdateUI();
                return false;
            }
        }*/

        if (colliders.Length > 1)  //Check if the object's collider intersects with more than 1 object (object always intersects with ground, hence value 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetToOriginalTansform()  //Reset the position and rotation to its initial values
    {
        transform.position = initialPos;
        transform.rotation = initialRot;
    }
}
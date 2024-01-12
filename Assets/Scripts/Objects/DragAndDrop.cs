using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
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

    public Material hologramMaterial;
    private GameObject hologramInstance;

    private void Start()
    {
        initialPos = transform.position;  //Save obj's start position
        initialRot = transform.rotation;
    }

    void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    TryStartDragging(touch.position);
                    break;

                case TouchPhase.Moved:
                    OnTouchMove(touch.position);
                    break;

                case TouchPhase.Ended:
                    OnTouchEnd();
                    break;
            }
        }
    }

    void TryStartDragging(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Check if the touch hits this object's collider
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            OnTouchStart(touchPosition);
        }
    }

    void OnTouchStart(Vector2 touchPosition)
    {
        if (objUI == null) return;

        if (IDManager.instance.isObjSelected == false)
        {
            IDManager.instance.isObjSelected = true;
            IDManager.instance.selectedID = ID;

            initialPos = transform.position;
            initialRot = transform.rotation;
        }

        if (IDManager.instance.selectedID == ID)
        {
            ConfirmPosition.instance.OpenObjUI();

            offset = transform.position - GetTouchWorldPos(touchPosition);
            isDragging = true;

            if (hologramInstance == null)
            {
                hologramInstance = Instantiate(gameObject, initialPos, initialRot);
                ApplyHologramMaterial(hologramInstance);
            }
        }
    }

    // Replace OnMouseUp with OnTouchEnd
    void OnTouchEnd()
    {
        isDragging = false;
    }

    // Modify GetMouseWorldPos to GetTouchWorldPos
    Vector3 GetTouchWorldPos(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, hoverAreaLayer))
        {
            mousePos = new Vector3(hit.point.x, 0f, hit.point.z);
        }

        return mousePos;
    }

    // Modify the Update function to handle touch move
    void OnTouchMove(Vector2 touchPosition)
    {
        if (isDragging)
        {
            transform.position = GetTouchWorldPos(touchPosition) + offset;

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
                boxCollider.gameObject.SetActive(false);  //Deactivate object (not destroy because destroy causes problems with ID handling)

                TrashBag.instance.UpdateUI();
                return false;
            }
        }

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
    private void ApplyHologramMaterial(GameObject obj)
    {
        if (hologramMaterial != null)
        {
            Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
            foreach (Renderer renderer in renderers)
            {
                renderer.material = hologramMaterial;
            }
        }
    }

    public void DestroyHologram()
    {
        if (hologramInstance != null)
        {
            Destroy(hologramInstance);
            hologramInstance = null;
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ConfirmPosition : MonoBehaviour
{
    public static ConfirmPosition instance;
    public GameObject objUI;  //Object UI (confirm, cancel, rotate)

    private int moveCount = 0;
    public TMP_Text moveCountText;

    private void Awake()
    {
        instance = this;
    }

    public void OpenObjUI()  //Open object UI
    {
        if (objUI != null)
        {
            objUI.SetActive(true);
        }
    }

    void CloseObjUI()  //Close object UI
    {
        if (objUI != null)
        {
            objUI.SetActive(false);
            IDManager.instance.isObjSelected = false;
        }
    }

    public void Confirm()
    {
        Debug.Log("Confirm");
        //Retrieve object's DragAndDrop script using the selectedID
        Transform Object = IDManager.instance.objects.GetChild(IDManager.instance.selectedID);
        DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

        bool isIntersecting = dndScript.CheckIntersecting();

        if (isIntersecting)
        {
            Cancel();
        }
        else
        {
            IncrementMoveCount();
            CloseObjUI();
        }
    }

    public void Cancel()
    {
        //Retrieve object's DragAndDrop script using the selectedID
        Transform Object = IDManager.instance.objects.GetChild(IDManager.instance.selectedID);
        DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

        dndScript.ResetToOriginalTansform();  //Call function to reset object's transform to initial transform
        CloseObjUI();
    }

    public void Rotate()
    {
        //Retrieve object's DragAndDrop script using the selectedID
        Transform Object = IDManager.instance.objects.GetChild(IDManager.instance.selectedID);
        DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

        dndScript.RotateObject();  //Call function to rotate the object
    }

    void IncrementMoveCount()
    {
        moveCount++;  //Increase move count
        moveCountText.text = moveCount.ToString();  //Update move counter indicator
    }
}

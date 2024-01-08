using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ConfirmPosition : MonoBehaviour
{
    public static ConfirmPosition instance;
    private Transform Object;
    public GameObject objUI;  //Object UI (confirm, cancel, rotate)

    public int moveCount = 0;
    public TMP_Text moveCountText;
    public TMP_Text panelMoveText;
    public GameObject panel;

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
            RetrieveObject();
            DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

            if (dndScript != null)
            {
                // Call DestroyHologram on the instance of DragAndDrop
                dndScript.DestroyHologram();
            }
        }
    }

    public void Confirm()
    {
        RetrieveObject();
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
        RetrieveObject();
        DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

        dndScript.ResetToOriginalTansform();  //Call function to reset object's transform to initial transform
        CloseObjUI();
    }

    public void Rotate()
    {
        RetrieveObject();
        DragAndDrop dndScript = Object.gameObject.GetComponent<DragAndDrop>();

        dndScript.RotateObject();  //Call function to rotate the object
    }

    private void RetrieveObject()
    {
        Transform ObjectsList = IDManager.instance.objects;
        int selectedID = IDManager.instance.selectedID;

        if (selectedID >= ObjectsList.childCount - 1)
        {
            Object = ObjectsList.Find("Trash").GetChild(selectedID - ObjectsList.childCount + 1);
        }
        else
        {
            Object = IDManager.instance.objects.GetChild(IDManager.instance.selectedID);
        }
    }

    void IncrementMoveCount()
    {
        moveCount++;  //Increase move count
        moveCountText.text = moveCount.ToString();  //Update move counter indicator
    }

    public void ShowPanelWithMove()
    {
        panelMoveText.text = moveCount.ToString();
    }
}

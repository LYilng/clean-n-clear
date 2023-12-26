using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public static IDManager instance;

    public Transform objects;

    public bool isObjSelected = false;
    public int selectedID;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < objects.childCount; i++)  //For every object that is a child of the 'Objects' game object,
        {
            Transform child = objects.GetChild(i);

            // Assign an ID to the child
            DragAndDrop dndScript = child.gameObject.GetComponent<DragAndDrop>();
            if (dndScript != null)
            {
                dndScript.ID = i;
            }
        }
    }
}

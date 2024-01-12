using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDManager : MonoBehaviour
{
    public static IDManager instance;

    public Transform objects;

    public bool isObjSelected = false;
    public int selectedID;

    private int currentIndex = 0;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        for (int i = 0; i < objects.childCount; i++)  //For every object that is a child of the 'Objects' game object,
        {
            Transform child = objects.GetChild(i);  //Objects list

            /* !!!IMPORTANT!!! Make sure trash game object is placed last within Objects list */
            if((child.gameObject.name).Equals("Trash"))  //If encounter trash list
            {
                for (int j = 0; j < child.childCount; j++)  //For every object that is a child of the trash list,
                {
                    Transform trashChild = child.GetChild(j);
                    DragAndDrop trashDNDScript = trashChild.gameObject.GetComponent<DragAndDrop>();

                    if (trashDNDScript != null)
                    {
                        trashDNDScript.ID = currentIndex;
                        currentIndex++;
                    }
                }
            }

            // Assign an ID to the child
            DragAndDrop dndScript = child.gameObject.GetComponent<DragAndDrop>();
            if (dndScript != null)
            {
                dndScript.ID = i;
                currentIndex++;
            }
        }
    }
}

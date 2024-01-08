using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatController : MonoBehaviour
{

    public GameObject objectToDelete;

    void Start()
    {
        if(PlayerPrefs.HasKey("ObjectToDeleteID"))
        {
            int objectToDelete = PlayerPrefs.GetInt("ObjectToDeleteID");

        }
    }


}

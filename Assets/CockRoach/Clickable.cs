using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clickable : MonoBehaviour
{
    //public int objectIDToDelete = 1;

    public void OnObjectClick()
    {
        //PlayerPrefs.SetInt("ObjectToDeleteID", objectIDToDelete);
        Debug.Log("Object clicked!");
        SceneManager.LoadScene("CockRoach");
    }

}

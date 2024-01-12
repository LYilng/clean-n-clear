using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestGameBtn : MonoBehaviour
{
    public static PestGameBtn instance;
    public bool PestBtnPressed = false;
    public GameObject PestCanvas;

    void Awake()
    {
        instance = this;
    }

    public void TogglePestBtn()
    {
        Debug.Log("PEST BTN PRESS");
        PestBtnPressed = true;
    }
}
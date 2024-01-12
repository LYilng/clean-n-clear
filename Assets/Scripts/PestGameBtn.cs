using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PestGameBtn : MonoBehaviour
{
    public static bool PestBtnPressed = false;
    public static bool GameWon = false;
    public GameObject PestCanvas;

    void Start()
    {
        if (PestCanvas == null) return;

        if(Input.GetMouseButtonDown(0) && PestBtnPressed)
        {
            PestCanvas.SetActive(true);
        }
    }

    public void TogglePestBtn()
    {
        PestBtnPressed = true;
    }
}

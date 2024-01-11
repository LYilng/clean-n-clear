using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TownCouncilBtn : MonoBehaviour
{
    public static bool TcIsPressed = false;
    public static bool QTEWin = false;
    public GameObject QTECanvas;

    void Update()
    {
        if (QTECanvas == null) return;

        if (Input.GetMouseButtonDown(0) && TcIsPressed) // Assuming you're using a mouse click for simplicity
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null && hit.collider.CompareTag("TCObject"))
                {
                    // Player pressed an object with the specific tag, activate the QTECanvas
                    QTECanvas.SetActive(true);
                }
            }
        }
        if (QTEWin)
        {
            QTECanvas.SetActive(false);
        }
    }

    public void ToggleTcBtn()
    {
        TcIsPressed = true;
    }
}

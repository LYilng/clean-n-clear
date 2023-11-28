using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoveCounter : MonoBehaviour
{
    private int moveCount = 0;
    public TMP_Text moveCountText;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateMoveCount();
        }
    }

    void UpdateMoveCount()
    {
        moveCount++;
        moveCountText.text = moveCount.ToString();
    }
}

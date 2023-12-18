using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpaceIndicator : MonoBehaviour
{
    public TextMeshProUGUI text;

    public void SetStartingText(int space)
    {
        UpdateText(space);
    }

    public void SetSpace(int space)
    {
        UpdateText(space);
    }

    private void UpdateText(int current)
    {
        text.text = $"{current}";
    }
}

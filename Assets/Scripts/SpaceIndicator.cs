using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class SpaceIndicator : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetStartingSpace(int space)
    {
        slider.maxValue = space;
        slider.value = 0;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetSpace(int space)
    {
        slider.value = space;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public Slider progressBar;
    public float increaseAmount = 0.1f;
    public Image image;

    private RectTransform imageTransform;
    private RectTransform canvasTransform;

    void Start()
    {
        imageTransform = image.GetComponent<RectTransform>();

        Canvas canvas = FindObjectOfType<Canvas>();

        if (canvas != null)
        {
            canvasTransform = canvas.GetComponent<RectTransform>();
        }
        else
        {
            Debug.LogError("Canvas component not found");
        }

    }


    public void IncreaseProgressBar()
    {
        progressBar.value += increaseAmount;

        if(progressBar.value >= progressBar.maxValue)
        {
            Debug.Log("Filled");

            if(canvasTransform != null & imageTransform != null)
            {
                imageTransform.anchoredPosition = Vector2.zero;
            }
        }
    }
}
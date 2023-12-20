using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TcQTE : MonoBehaviour
{
    public Slider progressBar;
    private float startValue = 0f;
    private float currentValue;
    private float maxValue = 10f;

    private float rate = 0.5f;
    private float decayRate = 0.5f;
    private bool isDecaying = false;

    void Start()
    {
        progressBar.value = startValue;
        progressBar.maxValue = maxValue;
        currentValue = startValue;


    }

    void Update()
    {
        // Transform rootTransform = transform.root;

        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     currentValue += rate;
        //     progressBar.value = currentValue;
        //     isDecaying = true;

        //     if (currentValue >= maxValue)
        //     {
        //         Debug.Log("U WINN");
        //         TownCouncilBtn.QTEWin = true;
        //         TownCouncilBtn.TcIsPressed = false;
        //         Debug.Log(currentValue);
        //         Destroy(rootTransform.gameObject);
        //     }
        // }

        if (currentValue <= 0f && isDecaying)
        {
            currentValue = 0f;
            isDecaying = false;
        }

        if (isDecaying)
        {
            currentValue -= decayRate * Time.deltaTime;
            progressBar.value = currentValue;
        }
    }

    public void countUp()
    {
        Transform rootTransform = transform.root;

        currentValue += rate;
        progressBar.value = currentValue;
        isDecaying = true;

        if (currentValue >= maxValue)
        {
            Debug.Log("U WINN");
            TownCouncilBtn.QTEWin = true;
            TownCouncilBtn.TcIsPressed = false;
            Debug.Log(currentValue);
            Destroy(rootTransform.gameObject);
        }
    }
}


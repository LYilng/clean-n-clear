using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{

    RectTransform recTransform;
    Canvas canvas;

    Vector2 targetPosition;
    float moveSpeed = 5f;


    void Start()
    {
        recTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void MoveToRandomPoint()
    {
        //Vector2 randomPosition = GetRandomPositionInCanvas();

        targetPosition = GetRandomPositionInCanvas();

        Vector2 direction = targetPosition - (Vector2)recTransform.anchoredPosition;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        recTransform.rotation = Quaternion.Euler(0f,0f,angle);


        

        StartCoroutine(MoveObject());

    }

    IEnumerator MoveObject()
    {
        float elapsedTime = 0f;
        Vector2 startingPos = recTransform.anchoredPosition;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * moveSpeed;
            recTransform.anchoredPosition = Vector2.Lerp(startingPos, targetPosition, elapsedTime);
            yield return null;
        }

        recTransform.anchoredPosition = targetPosition;

    }

    Vector2 GetRandomPositionInCanvas()
    {
        float canvasWidth = canvas.pixelRect.width;
        float canvasHeight = canvas.pixelRect.height;

        float randomX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
        float randomY = Random.Range(-canvasHeight / 2f, canvasHeight / 2f);

        return new Vector2(randomX, randomY);
    }

}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RatMovement : MonoBehaviour
{
    public static RatMovement instance;

    private Vector2 target; // The target location to move towards
    public float speed = 5f; // The speed at which the object moves
    public float timeBeforeChangeDir = 3f;
    private bool isMoving = false; // Flag to check if the rat is currently moving

    public bool isAlive = true;

    void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (isAlive)
        {
            timeBeforeChangeDir -= Time.deltaTime;

            if (!isMoving && timeBeforeChangeDir <= 0)
            {
                target = GetRandomPoint();
                timeBeforeChangeDir = 3f;
                isMoving = true; // Set the flag to indicate that the rat is now moving
            }

            if (isMoving)
            {
                MoveTowards(target);
            }
        }
    }

    private Vector2 GetRandomPoint()
    {
        RectTransform canvasRectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        float canvasWidth = canvasRectTransform.rect.width;
        float canvasHeight = canvasRectTransform.rect.height;

        float randomX = Random.Range(-canvasWidth / 2f, canvasWidth / 2f);
        float randomY = Random.Range(-canvasHeight / 2f, (canvasHeight / 2f) - 20f);

        return new Vector2(randomX, randomY);
    }

    void MoveTowards(Vector2 targetPosition)
    {
        Vector2 ratPos = GetComponent<RectTransform>().anchoredPosition;

        // Calculate the direction from the current position to the target position
        Vector2 direction = targetPosition - ratPos;

        // Normalize the direction to get a unit vector
        direction.Normalize();

        //Rotate towards moving direction
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the rotation to the sprite
        transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        // Move towards the target position
        GetComponent<RectTransform>().anchoredPosition += direction * speed * Time.deltaTime;

        // Check if the rat has reached the target
        if (Vector2.Distance(ratPos, targetPosition) < 0.1f)
        {
            isMoving = false; // Set the flag to indicate that the rat has reached the target
        }
    }

    public void ratAlive()
    {
        isAlive = true;
    }

    public void ratDied()
    {
        isAlive = false;
    }
}

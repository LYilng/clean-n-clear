using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStars : MonoBehaviour
{
    public static LevelStars instance;

    public Image moveStar;
    public Image timeStar;
    public Image healthStar;

    public Sprite fullStar;
    public Sprite blankStar;

    private int moveCount;
    private float timeCount;
    private int healthCount;

    public int maxMoveCount;
    public float maxTimeCount;

    void Awake()
    {
        instance = this;
    }

    public void MoveStarChecker()
    {
        moveCount = ConfirmPosition.instance.moveCount;
        Debug.Log("The number of moves made is: " + moveCount);

        if (moveCount > maxMoveCount)
        {
            moveStar.sprite = blankStar;
        }
        else
        {
            moveStar.sprite = fullStar;
        }
    }

    public void TimeStarChecker()
    {
        timeCount = Timer.instance.timer;
        Debug.Log("The time taken is: " + timeCount);

        if(timeCount > maxTimeCount)
        {
            timeStar.sprite = blankStar;
        }
        else
        {
            timeStar.sprite = fullStar;
        }
    }

    public void HealthStarChecker()
    {
        healthCount = Health.instance.currentHealth;
        Debug.Log("The lives left is " + healthCount);

        if(healthCount != Health.instance.maxHealth)
        {
            healthStar.sprite = blankStar;
        }
        else
        {
            healthStar.sprite = fullStar;
        }
    }
}

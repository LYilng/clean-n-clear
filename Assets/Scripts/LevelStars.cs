using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelStars : MonoBehaviour
{
    public static LevelStars instance;

    public Image moveStar;
    public Image timeStar;
    public Sprite fullStar;
    public Sprite blankStar;

    private int moveCount;
    private float timeCount;

    public int maxMoveCount;
    public float maxTimeCount;

    private ConfirmPosition confirmPosition;
    private Timer timerScript;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {

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
}

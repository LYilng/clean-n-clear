using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//public class StarsManager : MonoBehaviour
//{
//    public static StarsManager instance;

//    private string levelKey;

//    void Awake()
//    {
//        instance = this;
//    }

//    void Start()
//    {
//        levelKey = "Level" + SceneManager.GetActiveScene().buildIndex;
//        LoadStars();
//    }

//    public void SaveStars()
//    {
//        int earnedStars = 0;

//        if(LevelStars.instance.moveStar.sprite == LevelStars.instance.fullStar)
//        {
//            earnedStars++;
//        }

//        if (LevelStars.instance.timeStar.sprite == LevelStars.instance.fullStar)
//        {
//            earnedStars++;
//        }

//        if (LevelStars.instance.healthStar.sprite == LevelStars.instance.fullStar)
//        {
//            earnedStars++;
//        }

//        LoadStars();
//    }

//    public void LoadStars()
//    {
//        int earnedStars = PlayerPrefs.GetInt(levelKey, 0);

//        switch(earnedStars)
//        {
//            case 0:
//                LevelStars.instance.moveStar.sprite = LevelStars.instance.blankStar;
//                LevelStars.instance.timeStar.sprite = LevelStars.instance.blankStar;
//                LevelStars.instance.healthStar.sprite = LevelStars.instance.blankStar;
//                break;
//            case 1:
//                LevelStars.instance.moveStar.sprite = LevelStars.instance.fullStar;
//                LevelStars.instance.timeStar.sprite = LevelStars.instance.blankStar;
//                LevelStars.instance.healthStar.sprite = LevelStars.instance.blankStar;
//                break; 
//            case 2:
//                LevelStars.instance.moveStar.sprite = LevelStars.instance.fullStar;
//                LevelStars.instance.timeStar.sprite = LevelStars.instance.fullStar;
//                LevelStars.instance.healthStar.sprite = LevelStars.instance.blankStar;
//                break;
//            case 3:
//                LevelStars.instance.moveStar.sprite = LevelStars.instance.fullStar;
//                LevelStars.instance.timeStar.sprite = LevelStars.instance.fullStar;
//                LevelStars.instance.healthStar.sprite = LevelStars.instance.fullStar;
//                break;
//        }
//    }
//}

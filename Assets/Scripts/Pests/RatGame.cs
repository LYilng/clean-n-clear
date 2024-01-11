using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RatGame : MonoBehaviour
{
    public PauseMenu pauseMenu;

    public GameObject ratGame;
    public Transform gameEntities;

    static Transform ratTransform;

    public Image rat;
    public Sprite alive;
    public Sprite dead;

    private void OnMouseDown()
    {
        ratGame.SetActive(true);
        pauseMenu.HideCanvasElements();
        ratTransform = transform;

        foreach (Transform child in gameEntities)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void Return()
    {
        if (RatMovement.instance.isAlive == false)
        {
            ratTransform.gameObject.SetActive(false);
        }

        ratGame.SetActive(false);
        foreach (Transform child in gameEntities)
        {
            child.gameObject.SetActive(true);
        }

        RatMovement.instance.ratAlive();
        rat.sprite = alive;
    }

    public void Die()
    {
        RatMovement.instance.ratDied();
        rat.sprite = dead;
    }
}

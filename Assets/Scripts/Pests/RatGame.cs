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

    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // Check if the touch hits the object's collider
            if (touch.phase == TouchPhase.Began)
            {
                TryStartGame(touch.position);
            }
        }
    }

    void TryStartGame(Vector2 touchPosition)
    {
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hit;

        // Check if the touch hits the object's collider
        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        if(PestGameBtn.instance.PestBtnPressed == true)
        {
            ratGame.SetActive(true);
            pauseMenu.HideCanvasElements();
            ratTransform = transform;

            foreach (Transform child in gameEntities)
            {
                child.gameObject.SetActive(false);
            }
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Health : MonoBehaviour
{
    public static Health instance;

    public int currentHealth;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite blankHeart;

    public TMP_Text healthText;
    public TMP_Text movesGO;
    public TMP_Text timeGO;

    public GameObject canvasElements;
    public GameObject gameOverPanel;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth(); 
    }

    public void ReduceHealth(int amt)
    {
        currentHealth -= amt;
        Debug.Log("Health is now at: " + currentHealth);
        UpdateHealth();

        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    public void UpdateHealth()
    {
        for(int i = 0; i < hearts.Length; i++)
        {
            if(i < currentHealth)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = blankHeart;
            }
        }
    }

    public void GameOver()
    {
        CameraPPV.instance.SwitchToCamera();
        HideCanvasElements();

        movesGO.text = ConfirmPosition.instance.moveCount.ToString();
        timeGO.text = TimeSpan.FromSeconds(Timer.instance.timer).ToString(@"mm\:ss");
        gameOverPanel.SetActive(true);
    }

    public void HealthText()
    {
        if(healthText != null)
        {
            healthText.text = currentHealth.ToString();
        }
    }

    public void HideCanvasElements()
    {
        canvasElements.SetActive(false);
    }
}

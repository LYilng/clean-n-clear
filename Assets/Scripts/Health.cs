using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite blankHeart;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealth(); 
    }

    void Update()
    {

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
        Debug.Log("Level Failed");
    }
}

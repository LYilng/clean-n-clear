using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void ReduceHealth(int amt)
    {
        currentHealth -= amt;
        Debug.Log("Health is now at: " + currentHealth);

        if(currentHealth <= 0)
        {
            //GameOver
        }
    }

    void Update()
    {
        
    }
}

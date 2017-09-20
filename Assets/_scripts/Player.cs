using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public CharacterStat characterStat;

    public float maxHealth;
    public float currentHealth;

    private void Start()
    {
        characterStat = new CharacterStat(3,3,3,3);
        maxHealth = characterStat.GetHealth();
        currentHealth = maxHealth;
    }


    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Player Dead! Resetting health.");
        currentHealth = maxHealth;
    }
}

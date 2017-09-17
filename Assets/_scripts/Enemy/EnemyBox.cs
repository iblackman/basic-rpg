using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBox : Interactable, IEnemy {

    public CharacterStat EnemyStats;

    public float maxHealth = 10;

    private float currentHealth;

    public void Start()
    {
        EnemyStats = GetComponent<CharacterStat>();
        //currentHealth = EnemyStats.GetHealth();
        currentHealth = maxHealth;
        Debug.Log("Current health = " + currentHealth);
    }

    public void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    public void TakeDamage(int amount)
    {
        
        currentHealth -= amount;
        Debug.Log("Current health = " + currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

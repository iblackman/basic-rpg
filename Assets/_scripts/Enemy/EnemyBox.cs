using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;

public class EnemyBox : Interactable, IEnemy {

    private CharacterStat characterStat;
    private NavMeshAgent navAgent;
    private Collider[] aggroColliders;
    private Player player;
    private Vector3 startPosition;

    public LayerMask aggroLayerMask;
    public float maxHealth; 
    public float currentHealth;
    public float aggroRadius = 10f;
    public float attackSpeed = 2f;
    private float attackCooldown = 0f;

    public void Start()
    {
        navAgent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;
        characterStat = new CharacterStat(1,1,1,1);
        maxHealth = characterStat.GetHealth();
        currentHealth = maxHealth;
    }
    //isnt something that need to happend in the exact moment that it happens, so we can get some performance using FixedUpdate
    void FixedUpdate()
    {
        
        //create a sphere around the enemy to return all colliders from the layerMask passed
        aggroColliders = Physics.OverlapSphere(transform.position, aggroRadius, aggroLayerMask);
        if (aggroColliders.Length > 0)
        {
            ChasePlayer(aggroColliders[0].GetComponentInParent<Player>());
        }
        else
        {
            StopChasingPlayer();
        }
    }

    new void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void PerformAttack()
    {
        //Debug.Log("Enemy attacked "+ DateTime.Now.TimeOfDay.Seconds);
        player.TakeDamage(characterStat.GetDamage());
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void ChasePlayer(Player _player)
    {
        this.player = _player;
        navAgent.SetDestination(player.transform.position);
        if (navAgent.remainingDistance <= navAgent.stoppingDistance)
        {
            FaceTarget();
            if (attackCooldown <= 0f)
            {
                PerformAttack();
                attackCooldown = attackSpeed;
            }
        }

    }

    void FaceTarget()
    {
        Vector3 direction = (player.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    void StopChasingPlayer()
    {
        navAgent.SetDestination(startPosition);
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}

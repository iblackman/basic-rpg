using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {

    private Animator animator;
    //public Dictionary<Stats.Ref, BaseStat> Stats { get; set; }
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformBasicAttack(int _damage)
    {
        CurrentDamage = _damage;
        animator.SetTrigger("basic_attack");
    }

    public void PerformSecondaryAttack(int _damage)
    {
        CurrentDamage = _damage;
        animator.SetTrigger("secondary_attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            int dmg = CurrentDamage;
            other.GetComponent<EnemyBox>().TakeDamage(dmg);
        }
    }
}

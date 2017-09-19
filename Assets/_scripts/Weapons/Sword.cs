using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour, IWeapon {

    private Animator animator;
    //public Dictionary<Stats.Ref, BaseStat> Stats { get; set; }
    public List<BaseStat> Stats { get; set; }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void PerformBasicAttack()
    {
        animator.SetTrigger("basic_attack");
    }

    public void PerformSecondaryAttack()
    {
        animator.SetTrigger("secondary_attack");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            int dmg = Stats.Find(x => x.StatName == StatsRef.GetAtkName()).CalculateStatFinalValue();
            other.GetComponent<EnemyBox>().TakeDamage(dmg);
        }
    }
}

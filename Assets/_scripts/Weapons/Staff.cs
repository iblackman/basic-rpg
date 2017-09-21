using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Staff : MonoBehaviour, IWeapon, IProjectileWeapon
{

    private Animator animator;
    //public Dictionary<Stats.Ref, BaseStat> Stats { get; set; }
    public List<BaseStat> Stats { get; set; }
    public int CurrentDamage { get; set; }

    public Transform ProjectileSpawn { get; set; }

    Fireball fireball;

    void Start()
    {
        fireball = Resources.Load<Fireball>("projectiles/Basic_Fireball"); 
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

    public void CastProjectile()
    {
        Fireball fireballInstance = Instantiate<Fireball>(fireball, ProjectileSpawn.position, transform.rotation);
        fireballInstance.Damage += CurrentDamage;
        fireballInstance.Direction = ProjectileSpawn.forward;
    }
}
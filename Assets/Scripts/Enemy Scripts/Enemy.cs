using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected float health = 10f;
    public virtual void ApplyDamage(float damage)
    {
        health -= damage;   
        if(health <= 0)
        {
            Die();
        }
    }
    protected abstract void Die();
}

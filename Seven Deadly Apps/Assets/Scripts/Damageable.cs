using System;
using UnityEngine;

public abstract class Damageable : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float health;

    protected virtual void Awake()
    {
        health = maxHealth;
    }

    public void Damage()
    {
        health--;
    }
    
    public void Heal()
    {
        health++;
    }
}

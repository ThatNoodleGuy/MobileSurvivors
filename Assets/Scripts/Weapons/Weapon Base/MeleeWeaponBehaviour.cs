using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeaponBehaviour : MonoBehaviour
{
<<<<<<< HEAD
    [SerializeField] private float destroyAfterSeconds;

=======
    [SerializeField] private WeaponScriptableObject weaponData;

    [SerializeField] private float destroyAfterSeconds;

    // Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    protected virtual void Awake()
    {
        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
    }

>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    protected virtual void Start()
    {
        Destroy(gameObject, destroyAfterSeconds);
    }
<<<<<<< HEAD
=======

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyStats>())
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
        }
        else if (other.GetComponent<BreakableProps>())
        {
            BreakableProps props = other.GetComponent<BreakableProps>();
            props.TakeDamage(currentDamage);
        }
    }
    

>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
}
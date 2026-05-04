using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
<<<<<<< HEAD
=======
    [SerializeField] private WeaponScriptableObject weaponData;

>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    protected Vector3 direction;
    [SerializeField] private float destroyAfterSeconds = 4f;

    private float initialZ;

<<<<<<< HEAD
    protected virtual void Awake()
    {
        initialZ = transform.eulerAngles.z;
=======
    // Current stats
    protected float currentDamage;
    protected float currentSpeed;
    protected float currentCooldownDuration;
    protected int currentPierce;

    protected virtual void Awake()
    {
        initialZ = transform.eulerAngles.z;

        currentDamage = weaponData.Damage;
        currentSpeed = weaponData.Speed;
        currentCooldownDuration = weaponData.CooldownDuration;
        currentPierce = weaponData.Pierce;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    }

    protected virtual void Start()
    {
<<<<<<< HEAD
=======

>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
        Destroy(gameObject, destroyAfterSeconds);
    }

    public void DirectionChecker(Vector3 dir)
    {
        if (dir.sqrMagnitude < Mathf.Epsilon)
            dir = transform.right;

        direction = dir.normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, angle + initialZ);
    }
<<<<<<< HEAD
=======

    public WeaponScriptableObject GetWeaponData()
    {
        return weaponData;
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyStats>())
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);
            ReducePierce();
        }
        else if (other.GetComponent<BreakableProps>())
        {
            BreakableProps props = other.GetComponent<BreakableProps>();
            props.TakeDamage(currentDamage);
            ReducePierce();
        }
    }

    private void ReducePierce()
    {
        currentPierce--;
        if (currentPierce <= 0)
        {
            currentPierce = 0;
            Destroy(gameObject);
        }
    }
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
}
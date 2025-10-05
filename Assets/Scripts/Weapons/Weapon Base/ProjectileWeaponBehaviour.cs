using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeaponBehaviour : MonoBehaviour
{
    [SerializeField] private WeaponScriptableObject weaponData;

    protected Vector3 direction;
    [SerializeField] private float destroyAfterSeconds = 4f;

    private float initialZ;

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
    }

    protected virtual void Start()
    {

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
}
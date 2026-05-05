using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
<<<<<<< HEAD
    [SerializeField] private GameObject prefab;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float cooldownDuration;
    private float currentCooldown;
    [SerializeField] private int pierce;
=======
    [SerializeField] private WeaponScriptableObject weaponData;
    private float currentCooldown;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647

    protected PlayerController playerController;
    
    protected virtual void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
<<<<<<< HEAD
        
        currentCooldown = cooldownDuration;
=======

        currentCooldown = weaponData.CooldownDuration;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;

        if (currentCooldown <= 0)
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
<<<<<<< HEAD
        currentCooldown = cooldownDuration;
=======
        currentCooldown = weaponData.CooldownDuration;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647


    }

<<<<<<< HEAD
    public float GetDamage()
    {
        return damage;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetPierce()
    {
        return pierce;
    }

    public GameObject GetPrefab()
    {
        return prefab;
    }
    

=======
    public WeaponScriptableObject GetWeaponData()
    {
        return weaponData;
    }
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
}
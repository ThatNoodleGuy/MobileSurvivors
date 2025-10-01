using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private WeaponScriptableObject weaponData;
    private float currentCooldown;

    protected PlayerController playerController;
    
    protected virtual void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();

        currentCooldown = weaponData.CooldownDuration;
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
        currentCooldown = weaponData.CooldownDuration;


    }

    public WeaponScriptableObject GetWeaponData()
    {
        return weaponData;
    }
}
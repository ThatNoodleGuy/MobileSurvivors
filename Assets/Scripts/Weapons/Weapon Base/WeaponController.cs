using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    [SerializeField] private GameObject prefab;
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float cooldownDuration;
    private float currentCooldown;
    [SerializeField] private int pierce;

    protected PlayerController playerController;
    
    protected virtual void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        
        currentCooldown = cooldownDuration;
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
        currentCooldown = cooldownDuration;


    }

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
    

}
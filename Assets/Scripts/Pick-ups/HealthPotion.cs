using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    [SerializeField] private int healthToRestore;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = FindAnyObjectByType<PlayerStats>(); 
    }

    public void Collect()
    {
        playerStats.RestoreHealth(healthToRestore);
    }
}

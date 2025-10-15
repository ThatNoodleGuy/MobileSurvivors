using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceGem : Pickup, ICollectible
{
    [SerializeField] int experienceGranted;

    private PlayerStats playerStats;

    private void Start()
    {
        // playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
        playerStats = FindAnyObjectByType<PlayerStats>();
    }

    public void Collect()
    {
        playerStats.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour, ICollectible
{
    [SerializeField] int experienceGranted;

    private PlayerStats playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();
    }

    public void Collect()
    {
        playerStats.IncreaseExperience(experienceGranted);
        Destroy(gameObject);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private CharacterScriptableObject characterData;

    private float currentHealth;
    private float currentRecovery;
    private float currentMoveSpeed;
    private float currentMight;
    private float currentProjectileSpeed;

    public float CurrentHealth { get => currentHealth; set => currentHealth = value; }
    public float CurrentRecovery { get => currentRecovery; set => currentRecovery = value; }
    public float CurrentMoveSpeed { get => currentMoveSpeed; set => currentMoveSpeed = value; }
    public float CurrentMight { get => currentMight; set => currentMight = value; }
    public float CurrentProjectileSpeed { get => currentProjectileSpeed; set => currentProjectileSpeed = value; }

    // Experience and level
    [Header("Experience and Level")]
    [SerializeField] private int experience = 0;
    [SerializeField] private int level = 1;
    [SerializeField] private int experienceCap;

    public int Experience { get => experience; set => experience = value; }
    public int Level { get => level; set => level = value; }
    public int ExperienceCap { get => experienceCap; set => experienceCap = value; }

    [System.Serializable]
    public class LevelRange
    {
        public int startLevel;
        public int endLevel;
        public int experienceCapIncrease;
    }

    // IFrames
    [Header("IFrames")]
    [SerializeField] private float invincibilityDuration;
    float invincibilityTimer;
    bool isInvincible;

    [SerializeField] private List<LevelRange> levelRanges;

    private void Awake()
    {
        currentHealth = characterData.MaxHealth;
        currentRecovery = characterData.Recovery;
        currentMoveSpeed = characterData.MoveSpeed;
        currentMight = characterData.Might;
        currentProjectileSpeed = characterData.ProjectileSpeed;
    }


    private void Start()
    {
        // Initialize experience cap as the first level range experience cap
        experienceCap = levelRanges[0].experienceCapIncrease;
    }

    private void Update()
    {
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
        }
        else if (isInvincible)
        {
            isInvincible = false;
        }
    }

    public void IncreaseExperience(int amount)
    {
        experience += amount;
        LevelUpChecker();
    }

    private void LevelUpChecker()
    {
        if (experience >= experienceCap)
        {
            level += 1;
            experience -= experienceCap;

            int experienceCapIncrease = 0;
            foreach (LevelRange levelRange in levelRanges)
            {
                if (level >= levelRange.startLevel && level <= levelRange.endLevel)
                {
                    experienceCapIncrease += levelRange.experienceCapIncrease;
                }
            }
            experienceCap += experienceCapIncrease;
        }
    }

    public void TakeDamage(float damage)
    {
        if (!isInvincible)
        {    
            currentHealth -= damage;

            invincibilityTimer = invincibilityDuration;
            isInvincible = true;

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                Kill();
            }
        }
    }

    public void RestoreHealth(float amount)
    {
        if (CurrentHealth < characterData.MaxHealth)
        {
            CurrentHealth += amount;
            if (CurrentHealth > characterData.MaxHealth)
            {
                CurrentHealth = characterData.MaxHealth;
            }
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    // Base stats
    [SerializeField] private float moveSpeed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float damage;

    // Properties to access the stats
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float Damage { get => damage; private set => damage = value; }

}

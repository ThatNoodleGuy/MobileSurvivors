using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterScriptableObject", menuName = "ScriptableObjects/Character")]
public class CharacterScriptableObject : ScriptableObject
{
    [SerializeField] private Sprite icon;
    [SerializeField] private new string name;
    [SerializeField] private GameObject startingWeapon;
    [SerializeField] private float maxHealth;
    [SerializeField] private float recovery;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float might;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float magnet;

    public Sprite Icon { get => icon; private set => icon = value; }
    public string Name { get => name; private set => name = value; }
    public GameObject StartingWeapon { get => startingWeapon; private set => startingWeapon = value; }
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
    public float Recovery { get => recovery; private set => recovery = value; }
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
    public float Might { get => might; private set => might = value; }
    public float ProjectileSpeed { get => projectileSpeed; private set => projectileSpeed = value; }
    public float Magnet { get => magnet; private set => magnet = value; }
    
}

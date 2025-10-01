using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField] private GameObject prefab;

    // Base stats for the weapon
    [SerializeField] private float damage;
    [SerializeField] private float speed;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private int pierce;

    // Properties to access the stats
    public GameObject Prefab { get => prefab; private set => prefab = value; }
    public float Damage { get => damage; private set => damage = value; }
    public float Speed { get => speed; private set => speed = value; }
    public float CooldownDuration { get => cooldownDuration; private set => cooldownDuration = value; }
    public int Pierce { get => pierce; private set => pierce = value; }

}

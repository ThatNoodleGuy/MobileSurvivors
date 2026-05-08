using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "ScriptableObjects/Weapon")]
public class WeaponScriptableObject : ScriptableObject
{
    [SerializeField]
    GameObject prefab;
    public GameObject Prefab
    {
        get => prefab;
        private set => prefab = value;
    }

    //Base stats for the weapon
    [SerializeField]
    float damage;
    public float Damage
    {
        get => damage;
        private set => damage = value;
    }

    [SerializeField]
    float speed;
    public float Speed
    {
        get => speed;
        private set => speed = value;
    }

    [SerializeField]
    float cooldownDuration;
    public float CooldownDuration
    {
        get => cooldownDuration;
        private set => cooldownDuration = value;
    }

    [SerializeField]
    int pierce;
    public int Pierce
    {
        get => pierce;
        private set => pierce = value;
    }

    [SerializeField]
    int level; // not meant to be modified in game, only in editor
    public int Level
    {
        get => level;
        private set => level = value;
    }

    [SerializeField]
    GameObject nextLevelPrefab;

    // the prefab of the next level, IE, what the object will be upgraded to
    // not to be confused with the prefab that we spawn in the scene
    public GameObject NextLevelPrefab
    {
        get => nextLevelPrefab;
        private set => nextLevelPrefab = value;
    }

    [SerializeField]
    string name;
    public string Name
    {
        get => name;
        private set => name = value;
    }

    [SerializeField]
    string description; //what is the description of this weapon? [if this weapon is an upgrade, place the description of the upgrade here]
    public string Description
    {
        get => description;
        private set => description = value;
    }

    [SerializeField]
    Sprite icon;
    public Sprite Icon
    {
        get => icon;
        private set => icon = value;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PassiveItemScriptableObject",
    menuName = "ScriptableObjects/Passive Item"
)]
public class PassiveItemScriptableObject : ScriptableObject
{
    [SerializeField]
    float multiplier;
    public float Multiplier
    {
        get => multiplier;
        private set => multiplier = value;
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
    Sprite icon;
    public Sprite Icon
    {
        get => icon;
        private set => icon = value;
    }
}

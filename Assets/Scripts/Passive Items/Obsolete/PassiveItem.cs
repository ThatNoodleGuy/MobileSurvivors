using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Replaced by the Passive class, which works with PassiveData.")]
public class PassiveItem : MonoBehaviour
{
    protected PlayerStats player;
    public PassiveItemScriptableObject passiveItemData;

    protected virtual void ApplyModifier()
    {
        // Apply the boost value to the appropriate player stat in the child classes
    }

    void Start()
    {
        player = FindObjectOfType<PlayerStats>();
        ApplyModifier();
    }
}

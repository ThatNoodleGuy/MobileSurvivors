using System;
using UnityEngine;

/// <summary>
/// Base script for all weapon controllers. WeaponControllers are responsible for managing the cooldowns
/// of the weapons and firing them when the cooldown expires.
/// </summary>
 
[Obsolete("Replaced by the Weapon component, as this script uses the old WeaponScriptableObject class for its weapon data.",false)]
public class WeaponController : MonoBehaviour
{
    [Header("Weapon Stats")]
    public WeaponScriptableObject weaponData;
    float currentCooldown;

    protected PlayerMovement pm;


    protected virtual void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
        currentCooldown = weaponData.CooldownDuration; //At the start set the current cooldown to be cooldown duration
    }

    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if (currentCooldown <= 0f)   //Once the cooldown becomes 0, attack
        {
            Attack();
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = weaponData.CooldownDuration;
    }
}

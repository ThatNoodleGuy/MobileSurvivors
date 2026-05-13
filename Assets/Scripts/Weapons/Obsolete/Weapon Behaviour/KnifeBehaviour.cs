using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("Part of the old weapon system.")]
public class KnifeBehaviour : ProjectileWeaponBehaviour
{

    protected override void Start()
    {
        base.Start();
    }

    void Update()
    {
        transform.position += direction * currentSpeed * Time.deltaTime;    //Set the movement of the knife
    }
}

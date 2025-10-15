using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : WeaponController
{

    protected override void Start()
    {
        base.Start();
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();

        var spawnedKnife = Instantiate(GetWeaponData().Prefab, transform.position, GetWeaponData().Prefab.transform.rotation);

        Vector2 dir = playerController.GetPlayerMovementDirection();
        if (dir.sqrMagnitude < Mathf.Epsilon)
        {
            dir = playerController.GetLastPlayerMovementDirection();
        }

        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(dir);
    }


}
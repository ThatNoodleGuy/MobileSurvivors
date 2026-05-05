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

<<<<<<< HEAD
        // Keep the prefab's editor rotation (e.g., -45°)
        var spawnedKnife = Instantiate(GetPrefab(), transform.position, GetPrefab().transform.rotation);
        // or: var spawnedKnife = Instantiate(GetPrefab(), transform.position, Quaternion.identity); // <-- DON'T do this

        Vector2 dir = playerController.GetPlayerMovementDirection();
        if (dir.sqrMagnitude < Mathf.Epsilon)
            dir = playerController.GetLastPlayerMovementDirection();
=======
        var spawnedKnife = Instantiate(GetWeaponData().Prefab, transform.position, GetWeaponData().Prefab.transform.rotation);

        Vector2 dir = playerController.GetPlayerMovementDirection();
        if (dir.sqrMagnitude < Mathf.Epsilon)
        {
            dir = playerController.GetLastPlayerMovementDirection();
        }
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647

        spawnedKnife.GetComponent<KnifeBehaviour>().DirectionChecker(dir);
    }


}
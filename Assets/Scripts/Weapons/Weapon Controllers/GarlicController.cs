using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarlicController : WeaponController
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
        GameObject spawnedGarlic = Instantiate(GetPrefab(), transform.position, Quaternion.identity);
=======
        GameObject spawnedGarlic = Instantiate(GetWeaponData().Prefab, transform.position, Quaternion.identity);
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
        spawnedGarlic.transform.position = transform.position;
        spawnedGarlic.transform.parent = transform;
    }
}
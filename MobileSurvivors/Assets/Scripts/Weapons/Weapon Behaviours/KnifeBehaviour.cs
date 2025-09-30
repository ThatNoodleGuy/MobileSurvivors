using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
    private KnifeController knifeController;

    protected override void Start()
    {
        base.Start();

        knifeController = FindAnyObjectByType<KnifeController>();
    }

    private void Update()
    {
        transform.position += direction * knifeController.GetSpeed() * Time.deltaTime;
    }

}
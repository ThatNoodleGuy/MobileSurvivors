using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeBehaviour : ProjectileWeaponBehaviour
{
<<<<<<< HEAD
    private KnifeController knifeController;

=======
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    protected override void Start()
    {
        base.Start();

<<<<<<< HEAD
        knifeController = FindAnyObjectByType<KnifeController>();
=======
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    }

    private void Update()
    {
<<<<<<< HEAD
        transform.position += direction * knifeController.GetSpeed() * Time.deltaTime;
=======
        transform.position += direction * GetWeaponData().Speed * Time.deltaTime;
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    }

}
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GarlicBehaviour : MeleeWeaponBehaviour
{
    private List<GameObject> markedEnemies = new List<GameObject>();

    protected override void Start()
    {
        base.Start();
    }

    private void Update()
    {

    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.GetComponent<EnemyStats>() && !markedEnemies.Contains(other.gameObject))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(enemy.gameObject);        // Add to marked enemies list so it doesn't get hit again by the same garlic instance
        }
    }

}
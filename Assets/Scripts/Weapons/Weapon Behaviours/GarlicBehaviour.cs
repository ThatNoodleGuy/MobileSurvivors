using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GarlicBehaviour : MeleeWeaponBehaviour
{
<<<<<<< HEAD

=======
    private List<GameObject> markedEnemies = new List<GameObject>();
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647

    protected override void Start()
    {
        base.Start();
<<<<<<< HEAD


=======
>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
    }

    private void Update()
    {

    }

<<<<<<< HEAD
=======
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        base.OnTriggerEnter2D(other);

        if (other.GetComponent<EnemyStats>() && !markedEnemies.Contains(other.gameObject))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            enemy.TakeDamage(currentDamage);

            markedEnemies.Add(enemy.gameObject);        // Add to marked enemies list so it doesn't get hit again by the same garlic instance
        }
        else if (other.GetComponent<BreakableProps>() && !markedEnemies.Contains(other.gameObject))
        {
            BreakableProps props = other.GetComponent<BreakableProps>();
            props.TakeDamage(currentDamage);

            markedEnemies.Add(props.gameObject);        // Add to marked enemies list so it doesn't get hit again by the same garlic instance
        }
    }

>>>>>>> a6962ed9ff540302ed676fd9cfc0d63b667f0647
}
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableProps : MonoBehaviour
{
    [SerializeField] private float health;

    public void TakeDamage(float dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            health = 0;
            Kill();
        }
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}

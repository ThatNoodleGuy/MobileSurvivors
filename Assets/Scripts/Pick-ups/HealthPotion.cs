using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : Pickup, ICollectible
{
    // The amount of health to restore when this item is collected
    public int healthToRestore;

    public override void Collect()
    {
        if (hasBeenCollected)
        {
            return;    //If the item has already been collected, do not collect it again
        }
        else
        {
            base.Collect();
        }

        PlayerStats player = FindObjectOfType<PlayerStats>();
        player.RestoreHealth(healthToRestore);
    }
}

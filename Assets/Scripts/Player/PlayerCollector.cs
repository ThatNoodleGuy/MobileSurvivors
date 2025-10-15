using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has the ICollectible interface
        if (other.gameObject.TryGetComponent(out ICollectible collectible))
        {
            // if it is a collectible call the collect method
            collectible.Collect();
        }
    }

}

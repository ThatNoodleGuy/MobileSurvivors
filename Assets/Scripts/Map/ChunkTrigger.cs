using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkTrigger : MonoBehaviour
{
    [SerializeField] private GameObject targetMap;

    private MapController mapController;

    private void Start()
    {
        mapController = FindAnyObjectByType<MapController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            mapController.SetCurrentChunk(targetMap);
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerController>())
        {
            if (mapController.GetCurrentChunk() == targetMap)
            {
                mapController.SetCurrentChunk(null);
            }
        }
    }
}
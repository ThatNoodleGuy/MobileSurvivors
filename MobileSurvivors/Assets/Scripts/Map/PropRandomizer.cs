using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Random = UnityEngine.Random;

public class PropRandomizer : MonoBehaviour
{
    [SerializeField] private List<GameObject> propSpawnPoints;
    [SerializeField] private List<GameObject> propPrefabs;

    private void Start()
    {
        SpawnProps();
    }

    private void SpawnProps()
    {
        foreach (GameObject spawnPoint in propSpawnPoints)
        {
            int randomIndex = Random.Range(0, propPrefabs.Count);
            GameObject propPrefab = propPrefabs[randomIndex];

            Instantiate(propPrefab, spawnPoint.transform.position, Quaternion.identity, spawnPoint.transform);
        }
    }
}
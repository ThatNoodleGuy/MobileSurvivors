using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    public List<GameObject> terrainChunks;
    public GameObject player;
    public float checkerRadius;
    public Vector3 noTerrainPosition;
    public LayerMask terrainMask;
    public GameObject currentChunk;
    PlayerMovement pm;

    [Header("Optimization")]
    public List<GameObject> spawnedChunks;
    GameObject latestChunk;
    public float maxOpDist; //Must be greater than the length and width of the tilemap
    float opDist;
    float optimizerCooldown;
    public float optimizerCooldownDur;



    void Start()
    {
        pm = FindObjectOfType<PlayerMovement>();
    }

    void Update()
    {
        ChunkChecker();
        ChunkOptimzer();
    }

    void ChunkChecker()
    {
        if(!currentChunk)
        {
            return;
        }

        // Border-safe generation: always check all neighbors around the current chunk.
        // This avoids missing a chunk when crossing quickly between two chunk triggers.
        TrySpawnAt("Right");
        TrySpawnAt("Left");
        TrySpawnAt("Up");
        TrySpawnAt("Down");
        TrySpawnAt("Right Up");
        TrySpawnAt("Right Down");
        TrySpawnAt("Left Up");
        TrySpawnAt("Left Down");
    }

    void TrySpawnAt(string anchorName)
    {
        Transform anchor = currentChunk.transform.Find(anchorName);
        if (!anchor)
        {
            return;
        }

        if (!Physics2D.OverlapCircle(anchor.position, checkerRadius, terrainMask))
        {
            noTerrainPosition = anchor.position;
            SpawnChunk();
        }
    }

    void SpawnChunk()
    {
        int rand = Random.Range(0, terrainChunks.Count);
        latestChunk = Instantiate(terrainChunks[rand], noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    void ChunkOptimzer()
    {
        optimizerCooldown -= Time.deltaTime;

        if (optimizerCooldown <= 0f)
        {
            optimizerCooldown = optimizerCooldownDur;   //Check every 1 second to save cost, change this value to lower to check more times
        }
        else
        {
            return;
        }

        foreach (GameObject chunk in spawnedChunks)
        {
            opDist = Vector3.Distance(player.transform.position, chunk.transform.position);
            if (opDist > maxOpDist)
            {
                chunk.SetActive(false);
            }
            else
            {
                chunk.SetActive(true);
            }
        }
    }
}

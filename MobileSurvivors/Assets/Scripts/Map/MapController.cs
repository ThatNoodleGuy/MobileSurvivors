using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [Header("Terrain Chunks Settings")]
    [SerializeField] private List<GameObject> terrainChunks;
    [SerializeField] private GameObject player;
    [SerializeField] private LayerMask terrainLayerMask;
    [SerializeField] private float checkerRadius;
    [SerializeField] private GameObject currentChunk;

    [Header("Opimization")]
    [SerializeField] private List<GameObject> spawnedChunks;
    private GameObject latestChunk;
    [SerializeField] private float maxOpDist; // must be greater than the length and width of the tilemap
    private float opDist;
    private float optimizeCooldown;
    [SerializeField] private float optimizeCooldownDuration;

    private Vector3 noTerrainPosition;
    private Vector3 playerMovementDirection;

    private PlayerController playerController;

    private static string RIGHT_HASH = "Right";
    private static string LEFT_HASH = "Left";
    private static string UP_HASH = "Up";
    private static string DOWN_HASH = "Down";
    private static string UP_RIGHT_HASH = "UpRight";
    private static string UP_LEFT_HASH = "UpLeft";
    private static string DOWN_RIGHT_HASH = "DownRight";
    private static string DOWN_LEFT_HASH = "DownLeft";

    private void Start()
    {
        if (player != null)
        {
            playerController = player.GetComponent<PlayerController>();
        }

    }

    private void Update()
    {
        playerMovementDirection = playerController.GetPlayerMovementDirection();

        ChunkChecker();
        ChunkOpimizer();
    }

    private void ChunkChecker()
    {
        if (!currentChunk)
        {
            return;
        }

        if (playerMovementDirection.x > 0 && playerMovementDirection.y == 0) // right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(RIGHT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(RIGHT_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x < 0 && playerMovementDirection.y == 0) // left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(LEFT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(LEFT_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x == 0 && playerMovementDirection.y > 0) // up
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(UP_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(UP_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x == 0 && playerMovementDirection.y < 0) // down
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(DOWN_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(DOWN_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x > 0 && playerMovementDirection.y > 0) // up-right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(UP_RIGHT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(UP_RIGHT_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x < 0 && playerMovementDirection.y > 0) // up-left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(UP_LEFT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(UP_LEFT_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x > 0 && playerMovementDirection.y < 0) // down-right
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(DOWN_RIGHT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(DOWN_RIGHT_HASH).position;
                SpawnChunk();
            }
        }
        else if (playerMovementDirection.x < 0 && playerMovementDirection.y < 0) // down-left
        {
            if (!Physics2D.OverlapCircle(currentChunk.transform.Find(DOWN_LEFT_HASH).position, checkerRadius, terrainLayerMask))
            {
                noTerrainPosition = currentChunk.transform.Find(DOWN_LEFT_HASH).position;
                SpawnChunk();
            }
        }
    }

    private void SpawnChunk()
    {
        int randomIndex = UnityEngine.Random.Range(0, terrainChunks.Count);
        GameObject terrainChunk = terrainChunks[randomIndex];

        latestChunk = Instantiate(terrainChunk, noTerrainPosition, Quaternion.identity);
        spawnedChunks.Add(latestChunk);
    }

    private void ChunkOpimizer()
    {
        optimizeCooldown -= Time.deltaTime;
        if (optimizeCooldown <= 0f)
        {
            optimizeCooldown = optimizeCooldownDuration;

        }
        else
        {
            return;
        }

        if (spawnedChunks.Count <= 1)
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

    public GameObject GetCurrentChunk()
    {
        return currentChunk;
    }

    public void SetCurrentChunk(GameObject chunk)
    {
        currentChunk = chunk;
    }
    
}
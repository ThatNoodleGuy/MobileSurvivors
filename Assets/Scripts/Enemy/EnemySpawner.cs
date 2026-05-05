using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {
        public string waveName;
        public int waveQuota; // the total number of enemies to spawn in this wave
        public float spawnInterval; // the interval between each enemy spawn
        public int spawnCount; // the number of enemies already spawned in this wave
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSpawner : MonoBehaviour
{
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] float SpawnRate = 1f;
    public GameObject[] ActorPrefab;

    public float spawnRate = 2f;

    
    private float spawnTimer = 0f;

    void Start()
    {
        
    }


    void Update()
    {
        // Update the spawn timer
        spawnTimer -= Time.deltaTime;

        // If the spawn timer reaches zero or less
        if (spawnTimer <= 0f)
        {
            // Spawn enemies at all spawn points
            SpawnActors();

            // Reset the spawn timer
            spawnTimer = spawnRate;
        }
        
    }

    private void SpawnActors()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            // Randomly select an enemy prefab from the array
            GameObject randomEnemyPrefab = ActorPrefab[Random.Range(0, ActorPrefab.Length)];

            // Instantiate a new enemy GameObject at the spawn point
            Instantiate(randomEnemyPrefab, spawnPoints[i].position, Quaternion.identity);
        }
    }
}

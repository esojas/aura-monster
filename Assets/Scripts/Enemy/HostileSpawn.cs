using System.Collections.Generic;
using UnityEngine;

public class HostileSpawn : MonoBehaviour
{
    [SerializeField] private Transform[] spawnPos;
    [SerializeField] private EnemyData[] enemyDataArray;
    [SerializeField] private float obstacleSpawnProbability;
    [SerializeField] private GameObject obstaclePrefab;

    private EnemyData GetWeightedRandomEnemy()
    {
        float totalWeight = 0f;
        foreach (var enemy in enemyDataArray)
            totalWeight += enemy.spawnProbability;

        float roll = Random.Range(0f, totalWeight);
        float cumulative = 0f;

        foreach (var enemy in enemyDataArray)
        {
            cumulative += enemy.spawnProbability;
            if (roll <= cumulative)
                return enemy;
        }

        return enemyDataArray[enemyDataArray.Length - 1];
    }

    private void RandomSpawn()
    {
        List<Transform> availablePoints = new List<Transform>(spawnPos);

        while (availablePoints.Count > 0)
        {
            int randomIndex = Random.Range(0, availablePoints.Count);
            Transform spawnPoint = availablePoints[randomIndex];
            availablePoints.RemoveAt(randomIndex);

            if (Random.value <= obstacleSpawnProbability)
            {
                Instantiate(obstaclePrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
            else
            {
                EnemyData chosenEnemy = GetWeightedRandomEnemy();
                GameObject enemyInstance = Instantiate(chosenEnemy.enemyPrefab, spawnPoint.position, spawnPoint.rotation, spawnPoint);
            }
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RandomSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

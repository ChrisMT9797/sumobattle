using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;

    private float spawnRange = 9;
    public int enemyCount;

    public int waveNumber = 1;

    public GameObject PowerupPrefab;
    // Start is called before the first frame update
    void Start()
    { 
        SpawnEnemyWave(waveNumber);
        Instantiate(PowerupPrefab, GenerateSpawnPosition(), PowerupPrefab.transform.rotation);
    }
    void SpawnEnemyWave(int enemmiesToSpawn)
    {
        for (int i = 0; i < enemmiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++; SpawnEnemyWave(waveNumber);
            Instantiate(PowerupPrefab, GenerateSpawnPosition2(), PowerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;
    }
    private Vector3 GenerateSpawnPosition2()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}


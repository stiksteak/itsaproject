using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnmanager : MonoBehaviour
{
    private float spawnRange = 5;
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public int waveNumber = 1;
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0 )
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation); waveNumber++; SpawnEnemyWave(waveNumber);
        }
    }
    void SpawnEnemyWave (int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(),
                enemyPrefab.transform.rotation);
        }
    }
    private Vector2 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-5, 5);
        float spawnPosY = Random.Range(5, 3);
        Vector2 randomPos = new Vector2 (spawnPosX, spawnPosY);
        return randomPos;
    }
}

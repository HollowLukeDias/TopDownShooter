using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnEffect;
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    private float timeUntilSpawns;
    public float initialTimeUntilSpawns = .25f;
    private int random;

    private void Start()
    {
        timeUntilSpawns = initialTimeUntilSpawns;
    }

    private void Update()
    {
        if (timeUntilSpawns <= 0)
        {
            if (Enemy.amountOfEnemies >= 100)
            {
                return;
            }
            random = Random.Range(0, spawnPoints.Length - 1);
            StartCoroutine(StartSpawn());
            timeUntilSpawns = initialTimeUntilSpawns;
        }
        else
        {
            timeUntilSpawns -= Time.deltaTime;
        }

    }
    IEnumerator StartSpawn()
    {
        GameObject effect = Instantiate(spawnEffect, spawnPoints[random].position, Quaternion.identity);
        Destroy(effect, 1.5f);
        yield return new WaitForSecondsRealtime(1.5f);
        Instantiate(enemyPrefab, spawnPoints[random].position, Quaternion.identity);
        Enemy.amountOfEnemies++;

    }
}

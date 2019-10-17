using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    public float maxPossibleY = 0;
    public float minPossibleY = 0;
    public float maxPossibleX = 0;
    public float minPossibleX = 0;
    public int enemiesInWave = 20;
    public GameObject spawnEffect;
    public GameObject enemyPrefab;
    private float timeUntilSpawns;
    public float initialTimeUntilSpawns = 2;
    public float minX = 7f;
    public float maxX = 20f;
    public float minY = 10f;
    public float maxY = 30f;

    private void Start()
    {
        timeUntilSpawns = initialTimeUntilSpawns;
    }
    private void Update()
    {
        if (timeUntilSpawns <= 0)
        {
            if (Enemy.amountOfEnemies >= enemiesInWave)
            {
                return;
            }
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
        GameObject effect = Instantiate(spawnEffect, GetSpawnPosition(), Quaternion.identity);
        Destroy(effect, 1.5f);
        yield return new WaitForSecondsRealtime(1f);
        Instantiate(enemyPrefab, GetSpawnPosition(), Quaternion.identity);
        Enemy.amountOfEnemies++;

    }

    public float RandomizeOuterCircle(float minN, float maxN)
    {
        float n = Random.Range(minN, maxN);
        int x = Random.Range(1, 3);
        int y = Random.Range(1, 3);
        if (x == 2)
        {
            n *= -1f;
        }
        if (y == 2)
        {
            n *= -1f;
        }

        return n;
        
    }

    private Vector2 GetSpawnPosition()
    {
        float newXPosition=0;
        float newYPosition=0;
        for (int i = 0; i < 1000; i++)
        {
            newYPosition = RandomizeOuterCircle(minY, maxY) + this.transform.position.y;
            if ((newYPosition < maxPossibleX) && (newYPosition > minPossibleX))
            {
                break;
            }
        }
        for (int i = 0; i < 1000; i++) {
            newXPosition = RandomizeOuterCircle(minX, maxX) + this.transform.position.x;
            if ((newXPosition < maxPossibleX) && (newXPosition > minPossibleX)) {
                break;
            }
        }
        return (new Vector2(newXPosition, newYPosition));
    }
}

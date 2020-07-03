using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public float phaseLength = 15f;

    public EnemySpawner enemySpawner;
    public AsteroidSpawner asteroidSpawner;

    void Start()
    {
        StartCoroutine(asteroidSpawner.Spawn());
        StartCoroutine(AdvanceDifficulty());
    }

    private IEnumerator AdvanceDifficulty()
    {
        var score = FindObjectOfType<Score>();

        int enemySpawnCount = 5;

        int wave = 1;
        while (true)
        {
            if ((wave % 2) == 0)
            {
                asteroidSpawner.spawnCount++;
                enemySpawnCount++;
            }
            asteroidSpawner.spawnDelay -= 0.02f;
            asteroidSpawner.maxSpeed += 3;

            for (int j = 0; j < wave + 3; j++)
            {
                yield return StartCoroutine(enemySpawner.SpawnColumn(enemySpawnCount));
                yield return new WaitForSeconds(3f);
                
                score.IncrementWave();
            }

            // yield return new WaitForSeconds(phaseLength);
            wave++;
        }
    }
}

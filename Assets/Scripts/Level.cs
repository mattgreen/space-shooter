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
        for (int i = 0; ; i++)
        {
            if ((i % 2) == 0)
                asteroidSpawner.spawnCount++;

            asteroidSpawner.spawnDelay -= 0.02f;
            asteroidSpawner.maxSpeed += 3;

            for (int j = 0; j < i + 3; j++)
            {
                yield return StartCoroutine(enemySpawner.SpawnColumn(5));
                yield return new WaitForSeconds(3f);
            }

            // yield return new WaitForSeconds(phaseLength);
        }
    }
}

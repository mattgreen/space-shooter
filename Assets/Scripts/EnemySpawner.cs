using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        StartCoroutine(Spawn(5));    
    }

    private static Vector2 RandomSpawnLocation()
    {
        var camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        var horizontalMin = -halfWidth;
        var horizontalMax =  halfWidth;

        return new Vector2(Random.Range(horizontalMin, horizontalMax), halfHeight);
    }

    private IEnumerator Spawn(int waves)
    {
        for(int i = 0; i < waves; i++)
        {
            yield return SpawnColumn(5);
            yield return new WaitForSeconds(4);
        }
    }

    private IEnumerator SpawnColumn(int count)
    {
        var location = RandomSpawnLocation();
        for (int i = 0; i < count; i++)
        {
            var e = (GameObject)Instantiate(enemy);
            e.transform.position = location;

            yield return new WaitForSeconds(2);
        }
    }
}

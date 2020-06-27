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
            yield return SpawnColumn(8);
            yield return new WaitForSeconds(3);
        }
    }

    private IEnumerator SpawnColumn(int count)
    {
        var location = RandomSpawnLocation();
        for (int i = 0; i < count; i++)
        {
            var e = (GameObject)Instantiate(enemy);
            e.transform.position = location;
            e.GetComponent<Rigidbody2D>().velocity = Vector2.down * 40;

            yield return new WaitForSeconds(0.75f);
        }
    }
}

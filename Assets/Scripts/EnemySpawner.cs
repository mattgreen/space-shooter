using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public GameObject station;

    private static Vector2 RandomSpawnLocation()
    {
        var camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        var horizontalMin = -halfWidth;
        var horizontalMax =  halfWidth;

        return new Vector2(Random.Range(horizontalMin, horizontalMax) * 0.65f, halfHeight);
    }

    private static Vector2 RandomRightSpawn()
    {
        var camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        var horizontalMin = -halfWidth;
        var horizontalMax =  halfWidth;

        return new Vector2(horizontalMax, Random.Range(0, halfHeight));
    }

    public IEnumerator SpawnColumn(int columnCount)
    {
        var location = RandomSpawnLocation();
        for (int i = 0; i < columnCount; i++)
        {
            var e = (GameObject)Instantiate(enemy);
            e.transform.position = location;
            e.GetComponent<Rigidbody2D>().velocity = Vector2.down * 40;

            yield return new WaitForSeconds(1f);
        }
    }

    public void SpawnStation()
    {
        var location = RandomRightSpawn();

        var s = (GameObject)Instantiate(this.station);
        s.transform.position = location;
        s.GetComponent<Rigidbody2D>().velocity = Vector2.left * 20;
    }
}

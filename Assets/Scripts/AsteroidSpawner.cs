using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;

    public int maxSpeed = 40;

    public int spawnCount = 3;

    public float spawnDelay = 3.0f;

    void Start()
    {
        StartCoroutine(Spawn());
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

    private IEnumerator Spawn()
    {
        while (true)
        {
            for (int i = 0; i < spawnCount; i++)
            {
                var pos = RandomSpawnLocation();
                var obj = (GameObject)Instantiate(asteroid);
                obj.transform.position = pos;

                var scale = Random.Range(0.1f, 0.4f);
                obj.transform.localScale = new Vector3(scale, scale, scale);
                obj.GetComponent<Rigidbody2D>().mass = scale;
                obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(10, maxSpeed);
                obj.GetComponent<Rigidbody2D>().AddTorque(Random.Range(30, 500));
            }

            yield return new WaitForSeconds(spawnDelay);
        }
    }
}

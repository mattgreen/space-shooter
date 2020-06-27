using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;

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
            var pos = RandomSpawnLocation();
            var obj = (GameObject)Instantiate(asteroid);
            obj.transform.position = pos;

            var scale = Random.Range(0.1f, 0.4f);
            obj.transform.localScale = new Vector3(scale, scale, scale);
            obj.GetComponent<Rigidbody2D>().velocity = Vector2.down * Random.Range(10, 80);

            yield return new WaitForSeconds(1.0f);
        }
    }
}

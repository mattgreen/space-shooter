using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 30f;

    public float health = 100f;

    void OnBecameInvisible()
    {
        if (transform.position.y >= 0)
            return;

        Destroy(gameObject);
    }
}

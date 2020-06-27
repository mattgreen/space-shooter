using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 30f;

    public float health = 100f;

    public float collisionDamage = 40f;

    void OnBecameInvisible()
    {
        if (transform.position.y >= 0)
            return;

        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().ApplyDamage(collisionDamage);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float speed = 30f;

    public float health = 100f;

    public float collisionDamage = 40f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().ApplyDamage(collisionDamage);
        }
    }

    void Start()
    {
        GetComponent<Rigidbody2D>().AddTorque(Random.Range(30, 300));
        GetComponent<Rigidbody2D>().velocity = Vector2.down * speed;
    }
}

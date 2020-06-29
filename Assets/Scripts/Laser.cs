using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 350f;

    public float damage = 20f;

    public GameObject shooter;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (ReferenceEquals(shooter, col.gameObject))
            return;
        
        var health = col.gameObject.GetComponent<Health>();
        if (health == null)
            return;
            
        health.ApplyDamage(damage);
        
        Destroy(gameObject);
    }

    void Start()
    {
        // GetComponent<Rigidbody2D>().AddForce(Vector3.forward * speed, ForceMode2D.Impulse);
    }
}

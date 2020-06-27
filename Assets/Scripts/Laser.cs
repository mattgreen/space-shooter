using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float speed = 350f;

    public float damage = 20f;

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Ship")
            return;
        
        
        var health = col.gameObject.GetComponent<Health>();
        health.ApplyDamage(damage);
        

        Destroy(gameObject);
    }
    
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector3.up * speed, ForceMode2D.Impulse);
        GetComponent<AudioSource>().Play(0);
    }
}

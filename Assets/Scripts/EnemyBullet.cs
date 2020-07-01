using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
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
}

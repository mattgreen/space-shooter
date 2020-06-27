using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Start()
    {
        StartCoroutine(Move());
    }

    private IEnumerator Move()
    {
        var collider = GetComponent<Rigidbody2D>();
        while (isActiveAndEnabled) {
            collider.AddForce(Vector2.down * 300);
            yield return new WaitForSeconds(1.0f);
        }
    }
}

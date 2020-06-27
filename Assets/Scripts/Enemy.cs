using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        
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

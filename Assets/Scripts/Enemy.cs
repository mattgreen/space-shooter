using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnBecameInvisible()
    {
        if (transform.position.y >= 0)
            return;

        Destroy(gameObject);
    }
}

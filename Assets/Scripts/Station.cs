using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private Ship ship;

    void OnBecameInvisible()
    {
        if (transform.position.x >= 0)
            return;

        Destroy(gameObject);
    }

    public void Start()
    {
        ship = FindObjectOfType<Ship>();

        // StartCoroutine(Roam());
    }

    // private IEnumerator Roam()
    // {
    //     while (true)
    //     {

    //     }
    // }
}

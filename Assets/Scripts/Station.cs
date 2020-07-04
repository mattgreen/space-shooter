using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{
    private Ship ship;

    public AudioClip introduction;

    void OnBecameInvisible()
    {
        if (transform.position.x >= 0)
            return;

        Destroy(gameObject);
    }

    public void Start()
    {
        AudioSource.PlayClipAtPoint(introduction, Camera.main.transform.position);
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

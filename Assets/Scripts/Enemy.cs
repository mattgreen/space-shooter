using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject laser;

    private Ship ship;

    void OnBecameInvisible()
    {
        if (transform.position.y >= 0)
            return;

        Destroy(gameObject);
    }

    void Start()
    {
        ship = FindObjectOfType<Ship>();

        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            if (ship != null)
            {
                var shot = Instantiate(laser, transform.position, transform.rotation);
                var dir = ship.transform.position - shot.transform.position;

                shot.GetComponent<Rigidbody2D>().AddForce(dir.normalized * 65, ForceMode2D.Impulse);
                shot.GetComponent<Laser>().shooter = gameObject;
            }

            yield return new WaitForSeconds(1.5f);
        }
    }
}

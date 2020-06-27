using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float movementSpeed = 150;
    
    public GameObject projectile;

    public float fireDelta = 0.2f;

    private float fireCooldown = 0f;

    void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");

        GetComponent<Rigidbody2D>().velocity = new Vector2(x, y) * movementSpeed;
    }

    void Update()
    {
        fireCooldown -= Time.deltaTime;
        if(Input.GetKey("space") && fireCooldown <= 0)
        {
            fireCooldown = fireDelta;

            var size = GetComponent<BoxCollider2D>().size;
            var laserPos = transform.position;
            laserPos.y += 10;

            var proj = Instantiate(projectile, laserPos, transform.rotation);
        }

    }
}

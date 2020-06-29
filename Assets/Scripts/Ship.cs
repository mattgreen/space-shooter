using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float movementSpeed = 150;
    
    public GameObject projectile;

    public float fireDelta = 0.2f;

    public PlayerInput playerInput;

    private float fireCooldown = 0f;

    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().velocity = playerInput.movement * movementSpeed;

        fireCooldown -= Time.deltaTime;
        if(playerInput.firePressed && fireCooldown <= 0)
        {
            fireCooldown = fireDelta;

            var size = GetComponent<BoxCollider2D>().size;
            var laserPos = transform.position;
            laserPos.y += 10;

            var proj = Instantiate(projectile, laserPos, transform.rotation);
            proj.GetComponent<Laser>().shooter = gameObject;
            proj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350, ForceMode2D.Impulse);
            proj.GetComponent<AudioSource>().Play(0);
        }
    }
}

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

    private Vector2 bounds = new Vector2();
    
    private Vector2 size = new Vector2();

    void Start()
    {
        var camera = Camera.main;
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        bounds.x = halfWidth;
        bounds.y = halfHeight;

        size.x = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        size.y = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    void FixedUpdate()
    {
        var vel = playerInput.movement * movementSpeed;
        
        if (transform.position.x > -187 && transform.position.x < 187)
        {
            GetComponent<Rigidbody2D>().velocity = playerInput.movement * movementSpeed;
        }   
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }

        fireCooldown -= Time.deltaTime;
        if(playerInput.firePressed && fireCooldown <= 0)
        {
            fireCooldown = fireDelta;

            var size = GetComponent<BoxCollider2D>().size;
            var laserPos = transform.position;
            laserPos.y += 7;

            var proj = Instantiate(projectile, laserPos, transform.rotation);
            proj.GetComponent<Laser>().shooter = gameObject;
            proj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350, ForceMode2D.Impulse);
            proj.GetComponent<AudioSource>().Play(0);
        }
    }

    void LateUpdate()
    {
        var x = Mathf.Clamp(transform.position.x, -bounds.x + size.x, bounds.x - size.x);
        var y = Mathf.Clamp(transform.position.y, -bounds.y + size.y, bounds.y - size.y);

        transform.position = new Vector2(x, y);
    }
}

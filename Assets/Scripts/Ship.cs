using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ship : MonoBehaviour
{
    public UnityEvent destroyed;

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
        Vector3 movement = playerInput.movement;
        
        var target = transform.position + (movement * (movementSpeed * Time.deltaTime));
        GetComponent<Rigidbody2D>().MovePosition(target);

        fireCooldown -= Time.deltaTime;
        if(playerInput.firePressed && fireCooldown <= 0)
        {
            fireCooldown = fireDelta;
            
            var laserPos = transform.position + (Vector3.up * 7);

            var proj = Instantiate(projectile, laserPos, transform.rotation);
            proj.GetComponent<Laser>().shooter = gameObject;
            proj.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 350, ForceMode2D.Impulse);

            var source = proj.GetComponent<AudioSource>();
            AudioSource.PlayClipAtPoint(source.clip, Camera.main.transform.position);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var health = gameObject.GetComponent<Health>();

        if (col.gameObject.tag == "Asteroid")
        {
            health.ApplyDamage(40f);
        }
        else if (col.gameObject.tag == "Enemy")
        {
            health.ApplyDamage(40f);
        }
    }

    void OnDestroy()
    {
        Debug.Log("hi");
        destroyed.Invoke();
    }

    void LateUpdate()
    {
        var x = Mathf.Clamp(transform.position.x, -bounds.x + size.x, bounds.x - size.x);
        var y = Mathf.Clamp(transform.position.y, -bounds.y + size.y, bounds.y - size.y);

        transform.position = new Vector2(x, y);
    }
}

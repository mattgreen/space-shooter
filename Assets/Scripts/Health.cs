using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float startingHealth = 100f;

    public GameObject explosion;

    private float health;
    
    private new SpriteRenderer renderer;
    private Shader flashShader;
    private bool flashing;
    
    public void ApplyDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            var explosive = (GameObject)Instantiate(explosion);
            explosive.transform.position = transform.position;

            Destroy(gameObject);
        }
        else
        {
            if (!flashing)
                StartCoroutine(Flash());
        }
    }

    private IEnumerator Flash()
    {
        flashing = true;

        var shader = renderer.material.shader;
        renderer.material.shader = flashShader;
        yield return new WaitForSeconds(0.05f);
        renderer.material.shader = shader;
        yield return new WaitForSeconds(0.05f);

        flashing = false;
    }

    void Start()
    {
        health = startingHealth;
        renderer = GetComponent<SpriteRenderer>();
        flashShader = Shader.Find("GUI/Text Shader");
    }
}

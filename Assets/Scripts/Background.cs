using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    public float scrollSpeed = 0.01f;

    private new Renderer renderer;
    private Vector2 offset;

    void Start()
    {
        renderer = GetComponent<Renderer>();
        offset = renderer.material.mainTextureOffset;
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * scrollSpeed, 5);
        Vector2 off = new Vector2(offset.x, y);

        renderer.material.mainTextureOffset = off;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureMovement : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    private Renderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        meshRenderer.material.mainTextureOffset = new Vector2(0, offset);
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TexturaMovimento : MonoBehaviour
{
    private float scrollSpeed = 0.5f;

    void Update()
    {
        float offset = Time.time * scrollSpeed;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(0, offset);
    }
}

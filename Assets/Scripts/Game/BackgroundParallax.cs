using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    // Parallax speed
    private const float SPEED = 2.1f;
    private float offset = 0f;

    // Access to shader using Renderer
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();    
    }

    private void Update()
    {
        // Increment offset by speed * time
        offset += Time.deltaTime * SPEED;
        // Update offset value of the shader
        rend.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
    }
}

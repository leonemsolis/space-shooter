using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{
    private float offset = 0f;
    private const float SPEED = .3f;
    private Renderer rend;

    private void Start() {
        rend = GetComponent<Renderer>();    
    }
    private void Update()
    {
        offset += Time.deltaTime * SPEED;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0f, offset));
    }
}

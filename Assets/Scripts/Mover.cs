using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float SPEED;
    private Rigidbody _rb;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _rb.velocity = transform.forward * SPEED;
    }
}

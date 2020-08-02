using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    private Rigidbody _rb;
    private float speed = 80f;
    private float tilt = .3f;

    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = movement * speed;

        _rb.position = new Vector3 (_rb.position.x, 0.0f, _rb.position.z);

        _rb.rotation = Quaternion.Euler (0.0f, 0.0f, _rb.velocity.x * -tilt);
    }
}

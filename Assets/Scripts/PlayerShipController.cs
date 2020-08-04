using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] GameObject bulletPrefab;

    private Rigidbody _rb;

    // Movement
    private Rect bounds;
    private const float SPEED = 100f;
    private const float TILT = .3f;

    // Fire
    private const float FIRERATE = .25f;
    private float nextFire = 0f;

    private void Start() {
        _rb = GetComponent<Rigidbody>();

        bounds.xMin = -55f;
        bounds.xMax = 55f;
        bounds.yMin = -10f;
        bounds.yMax = 200f;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + FIRERATE;
            GameObject bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 4f), Quaternion.identity);
            bullet.transform.SetParent(transform);
        }
    }

    private void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = movement * SPEED;

        _rb.position = new Vector3 
        (
            Mathf.Clamp (_rb.position.x, bounds.xMin, bounds.xMax), 
            0.0f, 
            Mathf.Clamp (_rb.position.z, bounds.yMin, bounds.yMax)
        );
        _rb.position = new Vector3(_rb.position.x, 0.0f, _rb.position.z);

        _rb.rotation = Quaternion.Euler (0.0f, 0.0f, _rb.velocity.x * -TILT);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] Mover bulletPrefab;
    [SerializeField] GameObject playerExplosion;

    public delegate void Damaged();
    public static event Damaged OnDamage;

    private Rigidbody _rb;

    // Movement
    private Rect bounds;
    private const float SPEED = 100f;
    private const float TILT = .3f;

    // Fire
    private const float FIRERATE = .7f;
    private float nextFire = 0f;

    private void Start() {
        _rb = GetComponent<Rigidbody>();

        bounds.xMin = -55f;
        bounds.xMax = 55f;
        bounds.yMin = 30f;
        bounds.yMax = 200f;
    }

    private void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + FIRERATE;
            Mover bullet = Instantiate(bulletPrefab, transform.position + new Vector3(0f, 0f, 4f), Quaternion.identity);
            bullet.transform.SetParent(transform);
            bullet.SetSpeed(new Vector3(0f, 0f, 400f));
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

    private void OnTriggerEnter(Collider other) {
        if(other.tag == Constants.AsteroidTag) {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            if(OnDamage != null) {
                OnDamage();
            }
        }
    }
}

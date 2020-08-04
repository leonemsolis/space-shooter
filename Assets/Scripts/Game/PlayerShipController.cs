using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] GameObject playerExplosion;

    // "Damage" event for health bar
    public delegate void Damaged();
    public static event Damaged OnDamage;

    private Rigidbody _rb;
    private ObjectPooler objectPooler;
    private Joystick joystick;

    // Movement
    private Rect bounds;
    private const float SPEED = 100f;
    private const float TILT = .3f;

    // Fire
    private const float FIRERATE = .5f;
    private float nextFire = 0f;

    private void Start() {
        objectPooler = FindObjectOfType<ObjectPooler>();
        _rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        // Set bounds for player movement
        bounds.xMin = -55f;
        bounds.xMax = 55f;
        bounds.yMin = 30f;
        bounds.yMax = 200f;
    }

    private void Update() {
        Fire();
    }

    private void FixedUpdate ()
    {
        Move();
    }

    private void OnTriggerEnter(Collider other) {
        // If collided with asteroid create explosion and send signal
        if(other.tag == Constants.AsteroidTag) {
            Instantiate(playerExplosion, transform.position, Quaternion.identity);
            AudioManager.PlayPlayerExplosion();
            if(OnDamage != null) {
                OnDamage();
            }
        }
    }

    private void Fire() {
        // Fire if "nextFire" amount of seconds has passed
        if (Time.time > nextFire)
        {
            nextFire = Time.time + FIRERATE;

            AudioManager.PlayShoot();
            Mover bullet = objectPooler.SpawnFromPool(Constants.BulletPoolTag, transform.position + new Vector3(0f, 0f, 4f), Quaternion.identity).GetComponent<Mover>();
            bullet.SetSpeed(new Vector3(0f, 0f, 400f));
        }
    }

    private void Move() {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        if(moveHorizontal == 0f) {
            moveHorizontal = joystick.Horizontal;
        }
        if(moveVertical == 0) {
            moveVertical = joystick.Vertical;
        }

        Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        _rb.velocity = movement * SPEED;

        // Clamp player's position in bounds
        _rb.position = new Vector3 
        (
            Mathf.Clamp (_rb.position.x, bounds.xMin, bounds.xMax), 
            0.0f, 
            Mathf.Clamp (_rb.position.z, bounds.yMin, bounds.yMax)
        );
        _rb.position = new Vector3(_rb.position.x, 0.0f, _rb.position.z);

        // Rotate(tilt) player based on horizontal velocity
        _rb.rotation = Quaternion.Euler (0.0f, 0.0f, _rb.velocity.x * -TILT);
    }
}

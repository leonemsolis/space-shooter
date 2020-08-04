using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosion;
    [SerializeField] GameObject playerExplosion;

    private void OnTriggerEnter(Collider other) {
        if(other.tag != "Boundary") {
            Destroy(gameObject);
            
            Instantiate(asteroidExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            if(other.tag == "Player") {
                Instantiate(playerExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
                Destroy(other.gameObject);
            } else {
                Destroy(other.gameObject);
            }
        }
    }
}

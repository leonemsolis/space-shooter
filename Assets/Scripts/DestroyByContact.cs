using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosion;
    [SerializeField] GameObject playerExplosion;

    private void OnTriggerEnter(Collider other) {
        if(other.tag != Constants.BoundaryTag) {
            Destroy(gameObject);
            
            Instantiate(asteroidExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            if(other.tag == Constants.PlayerTag) {
                Instantiate(playerExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
                Destroy(other.gameObject);
            } else {
                Destroy(other.gameObject);
            }
        }
    }
}

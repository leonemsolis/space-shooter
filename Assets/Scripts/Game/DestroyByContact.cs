using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    // Particle system prefab
    [SerializeField] GameObject asteroidExplosion;

    // "Destroy" event
    public delegate void Destroyed();
    public static event Destroyed OnDestroy;

    private void OnTriggerEnter(Collider other) {
        if(other.tag != Constants.BoundaryTag) { // Ignore boundary
            gameObject.SetActive(false);
            
            AudioManager.PlayAsteroidExplosion();
            Instantiate(asteroidExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            
            // Destroy any object except player, player will handle collision on his own
            if(other.tag != Constants.PlayerTag) {
                other.gameObject.SetActive(false);

                // Send event, so that score could be incremented
                // Do not send if there're no listeners
                if(OnDestroy != null) { 
                    OnDestroy();
                }
            }
        }
    }

    // Destroy command
    public void DestoryOnVictory() {
        gameObject.SetActive(false);
        Instantiate(asteroidExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
    }
}

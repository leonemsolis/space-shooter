using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField] GameObject asteroidExplosion;

    public delegate void Destroyed();
    public static event Destroyed OnDestroy;

    private void OnTriggerEnter(Collider other) {
        if(other.tag != Constants.BoundaryTag) {
            Destroy(gameObject);
            
            Instantiate(asteroidExplosion, transform.position, Quaternion.Euler(-90f, 0f, 0f));
            if(other.tag != Constants.PlayerTag) {
                Destroy(other.gameObject);
                if(OnDestroy != null) {
                    OnDestroy();
                }
            }
        }
    }
}

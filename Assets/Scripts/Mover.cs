using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public void SetSpeed(float newSpeed) {
        GetComponent<Rigidbody>().velocity = transform.forward * newSpeed;
    }
}

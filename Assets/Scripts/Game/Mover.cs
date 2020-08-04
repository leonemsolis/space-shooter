using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    public void SetSpeed(Vector3 speed) {
        GetComponent<Rigidbody>().velocity = speed;
    }
}

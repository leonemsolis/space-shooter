using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour
{
    private const float TUMBLE = 5f;
    
    private void Start()
    {
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * TUMBLE; 
    }
}

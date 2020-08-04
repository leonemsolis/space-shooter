using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
{
    // If some object (bullet or asteroid) leaves scene boundary(cube), it'll be destroyed (Deactivated)
    private void OnTriggerExit(Collider other) {
        other.gameObject.SetActive(false);
    }
}

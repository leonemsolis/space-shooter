using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    // Current Health Points
    private int hp = 3;

    // Subscribe TakeDamage function to event on enable
    private void OnEnable() {
        PlayerShipController.OnDamage += TakeDamage;
    }

    // De-subscrib TakeDamage function from event on disable
    private void OnDisable() {
        PlayerShipController.OnDamage -= TakeDamage;
    } 

    public void TakeDamage() {
        // Reduce hp
        hp -= 1;
        // Disable last heart icon
        transform.GetChild(hp).gameObject.SetActive(false);
        // If no hp left send fail signal to game controller and destroy player ship
        if(hp == 0) {
            FindObjectOfType<GameController>().LevelFailed();
            Destroy(FindObjectOfType<PlayerShipController>().gameObject);
        }
    } 
}

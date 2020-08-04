using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIndicator : MonoBehaviour
{
    private int hp = 3;
    
    public void TakeDamage() {
        hp -= 1;
        transform.GetChild(hp).gameObject.SetActive(false);
        if(hp == 0) {
            FindObjectOfType<GameController>().LevelFailed();
            Destroy(FindObjectOfType<PlayerShipController>().gameObject);
        }
    }

    private void OnEnable() {
        PlayerShipController.OnDamage += TakeDamage;
    }

    private void OnDisable() {
        PlayerShipController.OnDamage -= TakeDamage;
    }    
}

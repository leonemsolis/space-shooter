using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject asteroidPrefab;
    [SerializeField] List<LevelInfo> levels;

    private void Start() {
        SpawnWaves();
    }

    private void SpawnWaves() {

    }
}

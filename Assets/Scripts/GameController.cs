using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] Mover asteroidPrefab;
    [SerializeField] List<LevelInfo> levels;

    private const float START_WAIT = 2f;

    private LevelInfo info;

    private void Start() {
        info = levels[PlayerPrefs.GetInt(Constants.CurrentlySelectedLevel, 1)-1];
        StartCoroutine(SpawnWaves());
    }


    private IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(START_WAIT);
        while (true)
        {
            Vector3 spawnPosition = new Vector3 (Random.Range (-50f, 50f), 0f, 240f);
            Quaternion spawnRotation = Quaternion.identity;
            Mover asteroid = Instantiate(asteroidPrefab, spawnPosition, spawnRotation);
            asteroid.SetSpeed(Random.Range(info.maxAsteroidSpeed, info.minAsteroidSpeed));
            yield return new WaitForSeconds (Random.Range(info.minRespawnTime, info.maxRespawnTime));
        }
    }
}

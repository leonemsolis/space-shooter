using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] Mover asteroidPrefab;
    [SerializeField] List<LevelInfo> levels;

    private const float START_WAIT = 2f;

    private LevelInfo info;

    private void Awake() {
        info = levels[PlayerPrefs.GetInt(Constants.CurrentlySelectedLevel, 1)-1];
        StartCoroutine(SpawnWaves());
    }

    public int GetTarget() {
        return info.target;
    }

    public void LevelFailed() {
        GetComponent<SceneChanger>().ChangeToLevelSelectionScene();
    }

    public void LevelCompleted() {
        PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+info.level.ToString(), 2);
        PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+(info.level+1).ToString(), 1);
        PlayerPrefs.Save();
        GetComponent<SceneChanger>().ChangeToLevelSelectionScene();
    }


    private IEnumerator SpawnWaves() {
        yield return new WaitForSeconds(START_WAIT);
        while (true)
        {
            Vector3 spawnPosition = new Vector3 (Random.Range (-50f, 50f), 0f, 240f);
            Quaternion spawnRotation = Quaternion.identity;
            Mover asteroid = Instantiate(asteroidPrefab, spawnPosition, spawnRotation);
            asteroid.SetSpeed(new Vector3(Random.Range(-40f, 40f), 0f, Random.Range(info.maxAsteroidSpeed, info.minAsteroidSpeed)));
            yield return new WaitForSeconds (Random.Range(info.minRespawnTime, info.maxRespawnTime));
        }
    }
}

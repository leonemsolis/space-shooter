using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // List of gameinfo scriptable objects
    [SerializeField] List<LevelInfo> levels;
    // Object pool for spawning asteroids
    private ObjectPooler objectPooler;

    // Time to wait until first asteroid comes in
    private const float START_WAIT = 2f;

    // Curent level info
    private LevelInfo info;

    private bool running = true;

    private void Start() {
        objectPooler = FindObjectOfType<ObjectPooler>();
        // Get info that player selected, using level selection
        info = levels[PlayerPrefs.GetInt(Constants.CurrentlySelectedLevel, 1)-1];
        // Spawn asteroids
        StartCoroutine(SpawnAsteroids());
    }

    // Used by score system
    public int GetTarget() {
        return info.target;
    }

    public void LevelFailed() {
        // Return to level selection scene if game is over
        GetComponent<SceneChanger>().ChangeToLoseScene();
    }

    public void LevelCompleted() {
        // Stop spawning asteroids
        running = false;
        // Destroy all asteroids in the scene
        foreach(DestroyByContact asteroid in FindObjectsOfType<DestroyByContact>()) {
            asteroid.DestoryOnVictory();
        }
        // Mark current level as completed, open next level if closed
        PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+info.level.ToString(), 2);
        if(PlayerPrefs.GetInt(Constants.LevelSelectionPrefix+(info.level+1).ToString(), 0) == 0) {
            PlayerPrefs.SetInt(Constants.LevelSelectionPrefix+(info.level+1).ToString(), 1);
        }
        PlayerPrefs.Save();
        // Return to level selection scene
        GetComponent<SceneChanger>().ChangeToWinScene();
    }


    private IEnumerator SpawnAsteroids() {
        // Wait a few seconds
        yield return new WaitForSeconds(START_WAIT);
        while (running)
        {
            // Pick random x coordinate within viewport
            Vector3 spawnPosition = new Vector3 (Random.Range (-50f, 50f), 0f, 240f);
            // Spawn asteroid
            Mover asteroid = objectPooler.SpawnFromPool(Constants.AsteroidPoolTag, spawnPosition, Quaternion.identity).GetComponent<Mover>();
            // Set random horizontal speed / Set random vertical speed using level info
            asteroid.SetSpeed(new Vector3(Random.Range(-40f, 40f), 0f, Random.Range(info.maxAsteroidSpeed, info.minAsteroidSpeed)));
            asteroid.transform.SetParent(transform);
            // Set random time until next asteroid using level info
            yield return new WaitForSeconds (Random.Range(info.minRespawnTime, info.maxRespawnTime));
        }
    }
}

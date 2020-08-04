using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Level", menuName="LevelInfo")]
public class LevelInfo : ScriptableObject
{
    // Current level index
    public int level;
    // Number of asteroids required to finish the level
    public int target;
    public int minAsteroidSpeed;
    public int maxAsteroidSpeed;
    // Min and max time to wait between asteroids
    public float minRespawnTime;
    public float maxRespawnTime;
}

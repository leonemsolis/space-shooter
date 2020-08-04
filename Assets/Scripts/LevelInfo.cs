using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="Level", menuName="LevelInfo")]
public class LevelInfo : ScriptableObject
{
    public int level;
    public int target;
    public int minAsteroidSpeed;
    public int maxAsteroidSpeed;
    public float minRespawnTime;
    public float maxRespawnTime;
}

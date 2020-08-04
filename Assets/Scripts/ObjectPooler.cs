using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Pool class for stores prefab, size and tag of current pool
    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int poolSize;
    }

    // There are 2 pools, one for asteroids and one for bullets
    [SerializeField] List<Pool> pools;
    [SerializeField] Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Start()
    {
        // Create pools
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach(Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();
            for(int i = 0; i < pool.poolSize; ++i) {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                obj.transform.SetParent(transform);
                objectPool.Enqueue(obj);
            }
            poolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {
        // Get object from pool, and enqueue it for later
        // Do not destroy object, deactivate it instead!
        if(poolDictionary.ContainsKey(tag)) {
            GameObject objectToSpawn = poolDictionary[tag].Dequeue();
            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;
            objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
        return null;
    }
}

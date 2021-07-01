using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField] private GameObject cubeMonster;
    [SerializeField] private float spawnDelay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ShouldSpawn())
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        nextSpawnTime = Time.time + spawnDelay;
        Instantiate(cubeMonster, transform.position, transform.rotation);
    }

    private bool ShouldSpawn()
    {
        if (Time.time > nextSpawnTime && LevelHandler.GetMonstersToBeSpawned() > 0)
        {
            LevelHandler.DecreaseMonstersToBeSpawnedAndIncreaseCurrentMonsters();
            return true;
        }
        return false;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class MonsterSpawner : MonoBehaviour
{
    private float nextSpawnTime;

    [SerializeField] private GameObject cubeMonster;
    [SerializeField] private GameObject cubeMonster2;
    private float spawnDelay = 2;
    
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
        
        Random random = new Random();
        if (random.Next(1, 100) > LevelHandler.GetChanceForCubeMonster2())
        {
            // spawn normal cubeMonster
            Instantiate(cubeMonster, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(cubeMonster2, transform.position, transform.rotation);
        }
        
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

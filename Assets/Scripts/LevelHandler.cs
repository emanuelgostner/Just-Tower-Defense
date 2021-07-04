using UnityEngine;
using UnityEngine.UI;

using UnityEngine;

public static class LevelHandler
{
    // handle monsters on playground
    private static int _userDifficultySelection = 3;
    private static int _monstersToBeSpawned = 3;
    private static int _monstersSpawned = 0;
    private static int _monstersDestroyed = 0;
    private static int _monstersDestroyedByReachingEnd = 0;

    // handle game balance
    private static int _currentRound = 1;
    private static int _chanceForCubeMonster2 = 5;
    private static Text _curLevel = GameObject.Find("currentLevel").GetComponent<Text>();
    
    // for calculations
    private static int _monstersToBeSpawnedAtMost = 5;
    private static int _timeForMonsterToPassToGoal = 6;

    // General getters
    public static int GetCurrentRound()
    {
        return _currentRound;
    }

    // Handles user difficulty input
    public static void SetMonstersToBeSpawned(int howManyMonstersEachRound)
    {
        _userDifficultySelection = howManyMonstersEachRound;
        _monstersToBeSpawned = _userDifficultySelection;
    }
    
    // Handles spawning of monsters
    public static int GetMonstersToBeSpawned()
    {
        return _monstersToBeSpawned;
    }

    public static int GetChanceForCubeMonster2()
    {
        return _chanceForCubeMonster2;
    }
    
    public static void DecreaseMonstersToBeSpawnedAndIncreaseSpawnedMonsters()
    {
        _monstersToBeSpawned--;
        _monstersSpawned++;
    }
    
    // Ausschüttung von Spielwährung, Levelbasierte Ausschüttung
    public static int GetCoinsPerFinishedRound(int currentRound)
    {
        if (currentRound > 0)
        {
            return (_monstersToBeSpawnedAtMost * (currentRound + 2) - GetCoinsPerFinishedRound(currentRound - 1)) /
                   _timeForMonsterToPassToGoal;
        }
        return 0;
    }

    // Handle new rounds and economy
    public static void IncreaseMonsterDestroyedByReachingEnd()
    {
        _monstersDestroyedByReachingEnd++;
        Debug.Log("End" + _monstersDestroyedByReachingEnd);
    }
    
    public static void MonsterDestroyed()
    {
        _monstersDestroyed++;
        Debug.Log("Total destroyed monsters " + _monstersDestroyed);
        StartNewRound();
    }

    public static void StartNewRound()
    {
        // check if all monsters were spawned and destroyed
        Debug.Log("Monsters to be spawned " + GetMonstersToBeSpawned());
        Debug.Log("Monsters to spawned " + _monstersSpawned);
        Debug.Log("_userDifficultySelection " + _userDifficultySelection);
        if (_monstersToBeSpawned == 0 && _monstersSpawned == _userDifficultySelection &&
            _monstersDestroyed >= _userDifficultySelection)
        {
            // increase coin balance and round
            CoinBalance.Instance.AddToCoinBalance(GetCoinsPerFinishedRound(_currentRound) * 50);
            _currentRound++;

            IncreaseCubeMonster2SpawningChance();
            
            // reset tracking variables
            _monstersSpawned = 0;
            _monstersDestroyed = 0;
            _monstersDestroyedByReachingEnd = 0;
            _monstersToBeSpawned = _userDifficultySelection;
            
            _curLevel.text = "Current Level: " + _currentRound;
        }
    }

    // statische Progressive Schwierigkeitserhöhung nach jeder Runde 
    // Schwierigkeit wird dynamisch, je nach Spielerkönnen, angepasst
    public static void IncreaseCubeMonster2SpawningChance()
    {
        if (_monstersDestroyedByReachingEnd == 0 && _chanceForCubeMonster2 < 95)
        {
            _chanceForCubeMonster2 += _userDifficultySelection;
        }
    }

    public static void ResetLevelHandler()
    {
        // handle monsters on playground
        _monstersToBeSpawned = _userDifficultySelection;
        _monstersSpawned = 0;
        _monstersDestroyed = 0;
        _monstersDestroyedByReachingEnd = 0;

        // handle game balance
        _currentRound = 1;
        _chanceForCubeMonster2 = 5;
    }
}
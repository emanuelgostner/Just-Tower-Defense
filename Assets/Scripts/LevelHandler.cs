using UnityEngine;
using UnityEngine.UI;

public static class LevelHandler
{
    private static int _userDifficultySelection = 3;
    private static int _monstersToBeSpawned = 3;
    private static int _currentMonsters = 0;
    private static int _monstersToBeSpawnedAtMost = 5;
    private static int _currentRound = 1;
    private static int _timeForMonsterToPassToGoal = 6;
    private static int _destroyedMonsters = 0;
    private static int _chanceForCubeMonster2 = 5;
    private static Text _curLevel = GameObject.Find("currentLevel").GetComponent<Text>();

    public static int GetCurrentRound()
    {
        return _currentRound;
    }

    public static int GetChanceForCubeMonster2()
    {
        return _chanceForCubeMonster2;
    }
    
    // Handles spawning of monsters
    public static int GetMonstersToBeSpawned()
    {
        return _monstersToBeSpawned;
    }
    
    public static int GetCurrentMonsters()
    {
        return _currentMonsters;
    }
    
    public static void DecreaseMonstersToBeSpawnedAndIncreaseCurrentMonsters()
    {
        _monstersToBeSpawned--;
        _currentMonsters++;
    }

    public static void DecreaseCurrentMonsters()
    {
        _currentMonsters--;
    }
    
    // Handles balance of game
    public static void SetMonstersToBeSpawned(int howManyMonstersEachRound)
    {
        _userDifficultySelection = howManyMonstersEachRound;
        _monstersToBeSpawned = _userDifficultySelection;
    }

    public static int GetCoinsPerFinishedRound(int currentRound)
    {
        if (currentRound != 0)
        {
            return (_monstersToBeSpawnedAtMost * (_currentRound + 2) - GetCoinsPerFinishedRound(_currentRound - 1)) /
                   _timeForMonsterToPassToGoal;
        }
        return 0;
    }

    // Handle rounds
    public static void StartNewRound()
    {
        
        CoinBalance.Instance.AddToCoinBalance(GetCoinsPerFinishedRound(_currentRound) * _destroyedMonsters / _userDifficultySelection * 50);
        // Increase chance for cubemonster2
        if (_destroyedMonsters == _userDifficultySelection && _chanceForCubeMonster2 <= 95)
        {
            _chanceForCubeMonster2 += 5;
        }
        _destroyedMonsters = 0;
        _currentRound++;
        // TODO: maybe a delay between rounds
        _monstersToBeSpawned = _userDifficultySelection;
        _curLevel.text = "Current Level: " + _currentRound;
    }

    public static void IncreaseDestroyedMonsters()
    {
        _destroyedMonsters++;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class DifficultyScreen : MonoBehaviour
{
    public enum Difficulty {
        Easy,
        Medium,
        Hard,
    };
    private static Difficulty difficulty = Difficulty.Medium;
    
    // Auswahl von verschiedenen Schwierigkeitsgraden 
    public void EasyButton()
    {
        difficulty = Difficulty.Easy;
        LevelHandler.SetMonstersToBeSpawned(3);
        ReturnToMainMenu();
    }
    
    public void MediumButton()
    {
        difficulty = Difficulty.Medium;
        LevelHandler.SetMonstersToBeSpawned(4);
        ReturnToMainMenu();
    }
    
    public void HardButton()
    {
        difficulty = Difficulty.Hard;
        LevelHandler.SetMonstersToBeSpawned(5);
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }

    public static Difficulty GetDifficulty()
    {
        return difficulty;
    }
}
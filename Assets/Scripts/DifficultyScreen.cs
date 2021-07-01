using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DifficultyScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void EasyButton()
    {
        //TODO: save diff in variable
        LevelHandler.SetMonstersToBeSpawned(3);
        ReturnToMainMenu();
    }
    
    public void MediumButton()
    {
        //TODO: save diff in variable
        LevelHandler.SetMonstersToBeSpawned(4);
        ReturnToMainMenu();
    }
    
    public void HardButton()
    {
        //TODO: save diff in variable
        LevelHandler.SetMonstersToBeSpawned(5);
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
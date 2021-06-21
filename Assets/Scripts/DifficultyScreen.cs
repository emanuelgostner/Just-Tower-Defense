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
        ReturnToMainMenu();
    }
    
    public void MediumButton()
    {
        //TODO: save diff in variable
        ReturnToMainMenu();
    }
    
    public void HardButton()
    {
        //TODO: save diff in variable
        ReturnToMainMenu();
    }

    private void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Scenes/MainMenu");
    }
}
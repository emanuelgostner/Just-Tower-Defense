using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DifficultyButton()
    {
        SceneManager.LoadScene("Scenes/DifficultyScreen");
    }

    public void QuitButton()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void StartGame()
    {
        CoinBalance.Instance.ResetCoinBalance();
        LevelHandler.ResetLevelHandler();
        SceneManager.LoadScene("Scenes/Game");
    }
}

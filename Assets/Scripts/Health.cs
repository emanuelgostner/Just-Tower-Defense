using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // The TextMesh Component
    private TextMesh tm;
    public int health = 3;

    // Set players health according to the picked difficulty
    void Start () {
        if (this.transform.parent.gameObject.CompareTag("Goal"))
        {
            switch (DifficultyScreen.GetDifficulty())
            {
                case DifficultyScreen.Difficulty.Easy:
                    health = health + 3;
                    break;
                case DifficultyScreen.Difficulty.Medium:
                    health = health + 0;
                    break;
                case DifficultyScreen.Difficulty.Hard:
                    health = health > 3 ? health - 3 : 3;
                    break;
            }
        }
        tm = GetComponent<TextMesh>();
        tm.text = Repeat("- ", health);
    }

    // Rotate health UI/Text always to players camera 
    void Update () {
        // Face the Camera
        transform.forward = Camera.main.transform.forward;
    }
    // Return the current Health by counting the '-'
    public int CurrentHealth()
    {
        return health;
    }
    // Create String with string s  based on the number n
    public static string Repeat(string s, int n)
        => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
    
    // Decrease the current Health of the GameObject
    public void Decrease(int amount = 1)
    {
        GameObject parent = this.transform.parent.gameObject;
        if(parent.CompareTag("Goal"))
        {
            DecreaseHealth(amount + LevelBasedHealthDecrease());
            if (health <=0)
            {
                SceneManager.LoadScene("Scenes/GameOverScreen");
            }
        }
        else if(parent.CompareTag("Enemy"))
        {
            DecreaseHealth(amount);
            if (health ==0)
            {
                Destroy(parent);
            }
        }
    }

    private void DecreaseHealth(int amount)
    {
        health = health -  amount;
        health = health < 0 ? 0 : health;
        tm.text = Repeat("- ", health);
    }
    /*
     * Levelbasierte Abzugshöhe der Lebenspunkte
     * Increase the lost health by 1 every 5 levels
     */
    private int LevelBasedHealthDecrease()
    {
        int levelChallengerValue = 5;
        int levelChallenger = LevelHandler.GetCurrentRound() / levelChallengerValue;
        return levelChallenger;
    }
}

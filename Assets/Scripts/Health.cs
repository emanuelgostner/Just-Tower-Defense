using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    // The TextMesh Component
    private TextMesh tm;
    public int health = 5;

    // Use this for initialization
    void Start () {
        tm = GetComponent<TextMesh>();
        tm.text = Repeat("- ", health);
    }

    // Update is called once per frame
    void Update () {
        // Face the Camera
        transform.forward = Camera.main.transform.forward;
    }
    // Return the current Health by counting the '-'
    public int CurrentHealth()
    {
        return health;
    }
    public static string Repeat(string s, int n)
        => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();
    // Decrease the current Health or open GameOver Scene if health reached 0
    public void Decrease() {
        if (health > 1)
        {
            health--;
            tm.text = Repeat("- ", health);
        }
        // Falls
        else if(this.name == "End")
        {
            SceneManager.LoadScene("Scenes/GameOverScreen");
        }
        else if(this.name == "Monster")
        {
            Destroy(this);
            LevelHandler.IncreaseDestroyedMonsters();
        }
    }
}

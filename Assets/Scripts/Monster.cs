using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    // Gegnerbasierte Abzugshöhe der Lebenspunkte
    public int monsterHealthReduceValue = 1;
    
    private void Start () {
        // Navigate to End
        var end = GameObject.Find("End");
        if (end)
            GetComponent<NavMeshAgent>().destination = end.transform.position;
    }
    // Monster collider ist activated. Means whenever this Object collides with another object the method OnTriggerEnter is called
    private void OnTriggerEnter(Collider co) {
        // If the collision object is "End" access its healthBar Script and call method to decrease health
        // Then destory monster object (gameObject = the gameObject this script is attached to)
        if (co.name == "End") {
            // 
            co.GetComponentInChildren<Health>().Decrease(monsterHealthReduceValue);
            // Destroys the monster after reaching the goal
            Destroy(gameObject);
            LevelHandler.DecreaseCurrentMonsters();

            if (LevelHandler.GetCurrentMonsters() == 0)
            {
                // Start new round, increase coin balance and current round, reset monster spawner
                LevelHandler.StartNewRound();
            }
        }
    }
}

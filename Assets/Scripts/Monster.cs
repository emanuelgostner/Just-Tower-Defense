using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    private bool _colliding = true;
    // Start is called before the first frame update
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
        if (co.name == "End" && _colliding)
        {
            _colliding = false;
            co.GetComponentInChildren<Health>().Decrease();
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed
    public float speed = 10;

    // Target (set by Tower)
    public Transform target;
    
    // FixedUpdate is called in the same cycles as the physics updates occur (is recommened for transformation changes)
    void FixedUpdate() {
        // Move bullet towards its target(Monster). If the target was already destroyed, the bullet is removed
        if (target) {
            // move this gameObject (bullet) closer to its target
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        } else {
            Destroy(gameObject);
        }
    }
    // If the bullet reaches its target(Monster), reduce the Monsters health and remove the bullet from the game
    void OnTriggerEnter(Collider co) {
        Health health = co.GetComponentInChildren<Health>();
        if (health) {
            health.Decrease();
            Destroy(gameObject);
        }
    }
}

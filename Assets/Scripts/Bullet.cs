using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Speed
    public float speed = 10;

    // Target (set by Tower)
    public Transform target;
    
    // FixedUpdate is called in the same cycles as the physics updates occur
    void FixedUpdate() {
        // Still has a Target?
        if (target) {
            // move this gameObject (bullet) closer to its target
            Vector3 dir = target.position - transform.position;
            GetComponent<Rigidbody>().velocity = dir.normalized * speed;
        } else {
            // Otherwise destroy self
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider co) {
        /*Health health = co.GetComponentInChildren<Health>();
        if (health) {
            health.Decrease();
            Destroy(gameObject);
        }*/
    }
}

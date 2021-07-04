using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Tower : MonoBehaviour
{
    /*
     * Functionality
     * Eeach second the tower spawns a bullet GameObject which moves toward the first Monster that is in the monsters list
     * The Monsters List changes as Monsters enter/leave the range of the Tower or get destroyed by other events
     */
    
    // The Bullet
    public GameObject bulletPrefab;
    private List<Collider> _monsters = new List<Collider>();

    // Start shooting cycle of the tower. Fixed value of 1 second
    void Start()
    {
        InvokeRepeating("shootCycle", 0f, 1.0f);
    }
    // Add Monsters that enter the range of the tower to its Monster list
    void OnTriggerEnter(Collider co) {
        // Was it a Monster? Then Shoot it
        if (co.GetComponent<Monster>()) {
            _monsters.Add(co);
        }
    }

    void OnTriggerExit(Collider co)
    {
        _monsters.Remove(co);
    }

    // cycle through Monsters list and pick the first Monster that is still existing.
    // Remove all the Monsters that are still in the List but have been destroyed (either by other towers or by reaching the goal)
    void shootCycle()
    {
        int tmp_i = 0;
        for(int i = 0; i<_monsters.Count;i++)
        {
            if(_monsters[i] != null)
            {
                shootMonster(_monsters[i]);
                tmp_i = i;
                break;
            }
        }
        _monsters.RemoveRange(0, tmp_i);
    }
    // Create bullet and set the bullets target to the actual targeted Monster
    void shootMonster(Collider co)
    {
        GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        g.GetComponent<Bullet>().target = co.transform;
    }
}

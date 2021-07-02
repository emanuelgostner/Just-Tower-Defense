using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Tower : MonoBehaviour
{
    // The Bullet
    public GameObject bulletPrefab;
    private List<Collider> _monsters = new List<Collider>();

    void Start()
    {
        InvokeRepeating("shootCycle", 0f, 1.0f);
    }
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
    void shootMonster(Collider co)
    {
        GameObject g = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        g.GetComponent<Bullet>().target = co.transform;
    }
}

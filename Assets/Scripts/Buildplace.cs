using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buildplace : MonoBehaviour {
    // Tower gameObject. Public variables can be assigned via GUI
    public GameObject towerPrefab;
    public Button placeTower;
    public Button upgradeTower;
    public Button removeTower;
    private int maxLevel = 2;
    private int curLevel = 0;


    // Built in unity function. Triggered when click and release
    void OnMouseUpAsButton() {
        // Build Tower above Buildplace
    	GameObject g = (GameObject)Instantiate(towerPrefab);
    	g.transform.position = transform.position + Vector3.up;
        if (curLevel == 0)
        {
            // place has no tower on it
            placeTower.gameObject.SetActive(true);
        }
    }

    void upgradeTowerMe()
    {
        CoinBalance coinBalance = CoinBalance.Instance;
    }
    
}
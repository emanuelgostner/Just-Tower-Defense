using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buildplace : MonoBehaviour {
    // Tower gameObject. Public variables can be assigned via GUI
    private GameObject towerSettings;
    public GameObject currentTower;
    private int maxLevel;
    private int curLevel = 0;
    public GameObject[] towerPrefabs;

    void Start()
    {
        towerSettings = GameObject.Find("TowerSettings");
        maxLevel = towerPrefabs.Length;
    }
    // Built in unity function. Triggered when click and release
    void OnMouseUpAsButton() {
        towerSettings.GetComponent<SelectedTower>().SetSelectedBuildplace(this.gameObject);
        Debug.Log("Buildplace clicked", this);
        // Build Tower above Buildplace
        /*GameObject g = (GameObject)Instantiate(towerPrefab0);
    	g.transform.position = transform.position + Vector3.up;
        if (curLevel == 0)
        {
            // place has no tower on it
            //placeTower0.gameObject.SetActive(true);
        }*/
    }

    public void placeTower()
    {
        //CoinBalance coinBalance = CoinBalance.Instance;
        Debug.Log("place Tower", this);
        currentTower = (GameObject)Instantiate(towerPrefabs[curLevel]);
        currentTower.transform.position = transform.position + Vector3.up;
        curLevel++;
    }
    public void upgradeTower()
    {
        //CoinBalance coinBalance = CoinBalance.Instance;
        Debug.Log("upgrade Tower", this);
    }
    public void removeTower()
    {
        //CoinBalance coinBalance = CoinBalance.Instance;
        Debug.Log("remove Tower", this);
    }

    public int getCurLevel()
    {
        return this.curLevel;
    }
    public int getMaxLevel()
    {
        return this.maxLevel;
    }
}
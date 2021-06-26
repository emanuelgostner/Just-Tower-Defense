using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Buildplace : MonoBehaviour {
    // Tower gameObject. Public variables can be assigned via GUI
    private GameObject towerSettings;
    public GameObject towerPrefab0;
    public GameObject towerPrefab1;
    public GameObject towerPrefab2;
    private int maxLevel = 2;
    private int curLevel = 0;

    void Start()
    {
        towerSettings = GameObject.Find("TowerSettings");
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
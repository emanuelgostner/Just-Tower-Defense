using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class Buildplace : MonoBehaviour {
    // Tower gameObject. Public variables can be assigned via GUI
    private GameObject towerSettings;
    public GameObject currentTower;
    private int maxLevel;
    private int curLevel = 0;
    public GameObject[] towerPrefabs;
    CoinBalance coinBalance = CoinBalance.Instance;
    public int towerCost = 50;

    void Start()
    {
        towerSettings = GameObject.Find("TowerSettings");
        maxLevel = towerPrefabs.Length;
        coinBalance.AddToCoinBalance(200);
    }
    // Built in unity function. Triggered when click and release
    void OnMouseUpAsButton() {
        if (!IsPointerOverUIObject())
        {
            Debug.Log("Buildplace clicked", this);
            // Set this Buildplace as the selected Buildplace in the TowerSettings handler
            towerSettings.GetComponent<SelectedTower>().SetSelectedBuildplace(this.gameObject);
        }
    }

    public void placeTower()
    {
        Debug.Log("place Tower", this);
        // Check if coinBalance is sufficient to place tower
        if (coinBalance.GetCoinBalance() >= towerCost)
        {
            currentTower = (GameObject)Instantiate(towerPrefabs[curLevel]);
            currentTower.transform.position = transform.position + Vector3.up;
            curLevel++;
            coinBalance.SubtractFromCoinBalance(towerCost);
        }
    }
    public void upgradeTower()
    {
        //CoinBalance coinBalance = CoinBalance.Instance;
        Debug.Log("upgrade Tower", this);
        if (coinBalance.GetCoinBalance() >= towerCost)
        {
            Destroy(currentTower);
            currentTower = (GameObject)Instantiate(towerPrefabs[curLevel]);
            currentTower.transform.position = transform.position + Vector3.up;
            curLevel++;
            coinBalance.SubtractFromCoinBalance(towerCost);
        }
    }
    public void removeTower()
    {
        //CoinBalance coinBalance = CoinBalance.Instance;
        Debug.Log("remove Tower", this);
        Destroy(currentTower);
        curLevel = 0;
    }
    //When Touching UI
    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    public int getCurLevel()
    {
        return this.curLevel;
    }
    public int getMaxLevel()
    {
        return this.maxLevel;
    }
    public int getTowerCost()
    {
        return this.towerCost;
    }
}
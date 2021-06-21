using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradeScreen : MonoBehaviour
{
    [Header("UI")]
    public Text entityNameText;
    public Text entityLevelText;
    public Text coinBalanceText;
    public Text currentDpsText;
    public Text upgradedDpsText;
    public Text upgradeCostText;

    public string entityName;
    public int entityLevel;
    public int currentDps;
    public int upgradedDps;
    public int upgradeCost;
    
    // Start is called before the first frame update
    void Start()
    {
        DisplayCoinBalance();
        
        entityNameText.text = entityName;
        DisplayChanges();
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoinBalance();
    }

    public void UpgradeButton()
    {
        CoinBalance.Instance.SubtractFromCoinBalance(upgradeCost);
        entityLevel++;
        currentDps = upgradedDps;
        //TODO: change upgradedDps and upgradeCost to new value


        DisplayChanges();
    }

    private void DisplayChanges()
    {
        entityLevelText.text = "Level " + entityLevel;
        currentDpsText.text = "current DPS" + currentDps;
        upgradedDpsText.text = "next lvl DPS" + upgradedDps;
        upgradeCostText.text = "upgrade cost" + upgradeCost;
        DisplayCoinBalance();
    }

    private void DisplayCoinBalance()
    {
        coinBalanceText.text = "Coin Balance: " + CoinBalance.Instance.GetCoinBalance();
    }
    
    public void BackButton()
    {
        //TODO: change to the right scene
        SceneManager.LoadScene("Scenes/Game");
    }
}
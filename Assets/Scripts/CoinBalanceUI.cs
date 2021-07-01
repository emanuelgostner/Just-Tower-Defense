using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBalanceUI : MonoBehaviour, ICoinBalanceSubscriber
{
    private Text _text;
    CoinBalance coinBalance = CoinBalance.Instance;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<Text>();
        _text.text = "Coins: " + coinBalance.GetCoinBalance();
        coinBalance.AddSubscriber(this);
    }

    public void CoinBalanceUpdate(int newBalance)
    {
        _text.text = "Coins: " + newBalance;
    }
}

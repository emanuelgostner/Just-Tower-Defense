using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class CoinBalance
{
    private static CoinBalance _instance = null;
    private static readonly object Padlock = new object();

    private static int _coinBalance = 100;
    private static List<ICoinBalanceSubscriber> subscribers = new List<ICoinBalanceSubscriber>();
    
    private CoinBalance()
    {
    }

    public static CoinBalance Instance
    {
        get
        {
            lock (Padlock)
            {
                _instance = new CoinBalance();
            }
            return _instance;
        }
    }

    public void AddToCoinBalance(int valueToBeAdded)
    {
        if (valueToBeAdded > 0)
        {
            _coinBalance += valueToBeAdded;
            UpdateBalance();
        }
    }
    
    public void SubtractFromCoinBalance(int valueToBeSubtracted)
    {
        if (valueToBeSubtracted > 0 && _coinBalance - valueToBeSubtracted >= 0)
        {
            _coinBalance -= valueToBeSubtracted;
            UpdateBalance();
        }
    }

    public int GetCoinBalance()
    {
        return _coinBalance;
    }

    public void AddSubscriber(ICoinBalanceSubscriber subscriber)
    {
        subscribers.Add(subscriber);
    }
    private void UpdateBalance()
    {
        Debug.Log("CoinBalance/updateBalance");
        foreach (var subscriber in subscribers)
        {
            subscriber.CoinBalanceUpdate(_coinBalance);
        }
    }
}

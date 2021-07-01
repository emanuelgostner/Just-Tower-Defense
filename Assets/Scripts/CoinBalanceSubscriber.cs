using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICoinBalanceSubscriber
{
    void CoinBalanceUpdate(int newBalance);

}

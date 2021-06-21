public class CoinBalance
{
    private static CoinBalance _instance = null;
    private static readonly object Padlock = new object();

    private int _coinBalance = 0;
    
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
        }
    }
    
    public void SubtractFromCoinBalance(int valueToBeSubtracted)
    {
        if (valueToBeSubtracted < 0 && _coinBalance - valueToBeSubtracted >= 0)
        {
            _coinBalance -= valueToBeSubtracted;
        }
    }

    public int GetCoinBalance()
    {
        return _coinBalance;
    }
}

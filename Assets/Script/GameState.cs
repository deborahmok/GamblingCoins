using UnityEngine;

public class GameState : MonoBehaviour
{
    public static GameState I { get; private set; }

    [SerializeField] public int coins = 0;
    public int Coins => coins;

    private void Awake()
    {
        if (I != null && I != this) { Destroy(gameObject); return; }
        I = this;
        DontDestroyOnLoad(gameObject);
    }

    // public void AddCoins(int amount)
    // {
    //     coins = Mathf.Max(0, coins + amount);
    //     // Later: update UI here
    //     // Debug.Log("Coins: " + coins);
    // }
    public void AddCoins(int amount)
    {
        coins = Mathf.Max(0, coins + amount);
        Debug.Log("Coins now: " + coins);
    }

    public bool SpendCoins(int amount)
    {
        if (coins < amount) return false;
        coins -= amount;
        return true;
    }
}
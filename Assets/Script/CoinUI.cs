using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    [SerializeField] private Image digit1;
    [SerializeField] private Image digit2;
    [SerializeField] private Sprite[] numberSprites; // size 10 (0-9)

    private void Update()
    {
        if (GameState.I == null) return;

        int coins = Mathf.Clamp(GameState.I.Coins, 0, 99);

        int tens = coins / 10;
        int ones = coins % 10;

        digit1.sprite = numberSprites[tens];
        digit2.sprite = numberSprites[ones];
    }
}
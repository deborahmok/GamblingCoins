using UnityEngine;
using TMPro;

public class CashOutScript : MonoBehaviour
{
    public GameObject gambleScreen;
    public GameObject cashOutScreen;
    public GameObject win;
    public GameObject lose;
    public GameObject noCoins;
    public int highScore;
    public int yourScore;

    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI yourScoreText;

    public GameObject highScoreObj;
    public GameObject yourScoreObj;
    public GameState gameScript;
    public PlayerOther playerScript;
    public GameObject obj;
    public GameObject obj2;
     public GameObject loseText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        cashOutScreen.SetActive(false);
        loseText.SetActive(false);
        highScore = 0;
        gameScript = obj.GetComponent<GameState>();

        playerScript = obj2.GetComponent<PlayerOther>();

    }

    // Update is called once per frame
    void Update()
    {
        if (gameScript.coins == 0 && playerScript.gambled)
        {
            gambleScreen.SetActive(false);
            cashOutScreen.SetActive(true);
            loseText.SetActive(true);
            highScoreObj.SetActive(false);
            yourScoreObj.SetActive(false);
            playerScript.gambled = false;
             Debug.Log("zero coins");
            
        }

    }

    public void cashingOut()
    {
        yourScore = gameScript.coins;
        if (yourScore > highScore)
        {
            highScore = yourScore;
        }
        highScoreText.text = "High Score: " + highScore.ToString();
        yourScoreText.text = "Your Score: " + yourScore.ToString();

        gambleScreen.SetActive(false);
        cashOutScreen.SetActive(true);
    }

    public void playAgain()
    {
        cashOutScreen.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        loseText.SetActive(false);
        noCoins.SetActive(false);
        gameScript.coins = 0;
    }
}

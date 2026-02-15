
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerOther : MonoBehaviour
{
    public GameObject gambleScreen;
    public GameObject chooseColor;
    public GameObject loseScreen;
    public GameObject howMuch;

    public GameObject win;
    public GameObject lose;
    public GameObject[] gamblingObjects;
    public GameObject obj;

     public GameObject noCoins;

    public GameState gameScript;

    public int coins_ = 0;

    public bool gambled = false;
    

    public int whatColor = -1;
    public int howMuchAmt = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gambleScreen.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        gameScript = obj.GetComponent<GameState>();
         noCoins.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        coins_ = gameScript.Coins;

        
        

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GamblingTable"))
        {
            Debug.Log("hit table");
            gambleScreen.SetActive(true);
            howMuch.SetActive(false);
             noCoins.SetActive(false);
            chooseColor.SetActive(true);
        }
    }

    public void ChoseBlackButton()
    {
        whatColor = 0;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(true);
        chooseColor.SetActive(false);
         noCoins.SetActive(false);


    }

    public void ChoseRedButton()
    {
        whatColor = 1;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(true);
        chooseColor.SetActive(false);
         noCoins.SetActive(false);


    }


    public void ALittleButton()
    {
       
        howMuchAmt = 10;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
        noCoins.SetActive(false);
        if (coins_ >= howMuchAmt)
        {
            int randOutcome = Random.Range(0, gamblingObjects.Length);
            GameObject obj_ = gamblingObjects[randOutcome];
            obj_.SetActive(true);
            if (obj_.CompareTag("Win"))
            {
                gameScript.coins += howMuchAmt;
            }
            else
            {
                gameScript.coins -= howMuchAmt;
            }
            gambled = true;

        }
        else
        {
            noCoins.SetActive(true);
        }
        Debug.Log("here");
           

    }

    public void HalfButton()
    {
        howMuchAmt = coins_ / 2;
        whatColor = 1;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
         noCoins.SetActive(false);
        if (coins_ >= howMuchAmt)
        {
            int randOutcome = Random.Range(0, gamblingObjects.Length);
            GameObject obj_ = gamblingObjects[randOutcome];
            obj_.SetActive(true);
            if (obj_.CompareTag("Win"))
            {
                gameScript.coins += howMuchAmt;
            }
            else
            {
                gameScript.coins -= howMuchAmt;
            }
            gambled = true;
            

        }
        else
        {
            noCoins.SetActive(true);
        }
           Debug.Log("here");


    }

    public void AllButton()
    {
        howMuchAmt = coins_;
        Debug.Log("chose button");
         gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
         noCoins.SetActive(false);
        if (coins_ >= howMuchAmt)
        {
            int randOutcome = Random.Range(0, gamblingObjects.Length);
            GameObject obj_ = gamblingObjects[randOutcome];
            obj_.SetActive(true);
            if (obj_.CompareTag("Win"))
            {
                gameScript.coins += howMuchAmt;
            }
            else
            {
                gameScript.coins -= howMuchAmt;
            }
            gambled = true;
             
             


        }
        else
        {
            noCoins.SetActive(true);
        }
        
        Debug.Log("here");

    }

    public void ExitButton()
    {
        gambled = false;
        Debug.Log("chose button");
        gambleScreen.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);
        noCoins.SetActive(false);
        

    }
    
}

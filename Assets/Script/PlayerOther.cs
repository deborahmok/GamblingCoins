
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class PlayerOther : MonoBehaviour
{
    public GameObject gambleScreen;
    public GameObject chooseColor;
    public GameObject howMuch;

    public GameObject win;
    public GameObject lose;
    public GameObject[] gamblingObjects;

    public int whatColor = -1;
    public int howMuchAmt = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gambleScreen.SetActive(false);
        win.SetActive(false);
        lose.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GamblingTable"))
        {
            Debug.Log("hit table");
            gambleScreen.SetActive(true);
            howMuch.SetActive(false);
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


    }

    public void ChoseRedButton()
    {
        whatColor = 1;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(true);
        chooseColor.SetActive(false);


    }


    public void ALittleButton()
    {
        howMuchAmt = 10;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
        int randOutcome = Random.Range(0, gamblingObjects.Length);
        gamblingObjects[randOutcome].SetActive(true);
           Debug.Log("here");



    }

    public void HalfButton()
    {
        howMuchAmt = 0;
        whatColor = 1;
        Debug.Log("chose button");
        gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
        int randOutcome = Random.Range(0, gamblingObjects.Length);
        gamblingObjects[randOutcome].SetActive(true);
           Debug.Log("here");


    }

    public void AllButton()
    {
        howMuchAmt = 0;
        Debug.Log("chose button");
         gambleScreen.SetActive(true);
        howMuch.SetActive(false);
        chooseColor.SetActive(false);
        int randOutcome = Random.Range(0, gamblingObjects.Length);
        gamblingObjects[randOutcome].SetActive(true);
          Debug.Log("here");

    }
    
}

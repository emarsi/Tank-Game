using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public int playerOneMoney = 0;
    public int playerTwoMoney = 0;

    public TMP_Text playerOneMoneyText;
    public TMP_Text playerTwoMoneyText;

    //access tank controller script
    Tank tank;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
    }

    public void GiveMoney(int money)
    {
        if (tank.playerOneTurn)
        {
            playerOneMoney += money;
        }
        else
        {
            playerTwoMoney += money;
        }
        UpdateMoney();
    }

    public void SpendMoney(int money)
    {
        //playerMoney -= money;
        UpdateMoney();
    }

    void UpdateMoney()
    {
        playerOneMoneyText.text = "$" + playerOneMoney;
        playerTwoMoneyText.text = "$" + playerTwoMoney;
    }
}

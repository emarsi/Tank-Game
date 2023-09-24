using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    //access other scripts
    PlayerMoney playerMoney;
    Tank tank;

    int price = 25;

    //change inventory in shop
    public TMP_Text splitInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.Find("Tank 1").GetComponent<PlayerMoney>();
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
    }

    public void Purchase()
    {
        if (playerMoney.playerOneMoney >= price)
        {
            tank.playerOneSplit++;
            playerMoney.SpendMoney(price);
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        splitInventory.text = "Inv: " + tank.playerOneSplit;
    }
}

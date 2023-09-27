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
    Inventory inventory;

    int price = 25;

    //change inventory in shop
    public TMP_Text splitInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.Find("Tank 1").GetComponent<PlayerMoney>();
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
        inventory = GameObject.Find("Tank 1").GetComponent<Inventory>();
    }

    public void Purchase()
    {
        if (playerMoney.playerOneMoney >= price)
        {
            inventory.Split++;
            playerMoney.SpendMoney(price);
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        splitInventory.text = "Inv: " + inventory.Split;
    }
}

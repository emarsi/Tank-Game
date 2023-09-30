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
    int price2 = 25;
    int price3 = 15;

    //change inventory in shop
    public TMP_Text splitInventory;
    public TMP_Text freezeInventory;
    public TMP_Text teleportInventory;

    // Start is called before the first frame update
    void Start()
    {
        playerMoney = GameObject.Find("Tank 1").GetComponent<PlayerMoney>();
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
        inventory = GameObject.Find("Tank 1").GetComponent<Inventory>();
    }

    public void PurchaseOne()
    {
        if (playerMoney.playerOneMoney >= price)
        {
            inventory.Split++;
            playerMoney.SpendMoney(price);
            UpdateInventory();
        }
    }
    public void PurchaseTwo()
    {
        if (playerMoney.playerOneMoney >= price2)
        {
            inventory.Freeze++;
            playerMoney.SpendMoney(price);
            UpdateInventory();
        }
    }
    public void PurchaseThree()
    {
        if (playerMoney.playerOneMoney >= price3)
        {
            inventory.Teleport++;
            playerMoney.SpendMoney(price);
            UpdateInventory();
        }
    }

    void UpdateInventory()
    {
        splitInventory.text = "Inv: " + inventory.Split;
        freezeInventory.text = "Inv: " + inventory.Freeze;
        teleportInventory.text = "Inv: " + inventory.Teleport;
    }
}

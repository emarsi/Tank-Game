using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMoney : MonoBehaviour
{
    public int playerMoney = 0;

    public TMP_Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoney();
    }

    public void GiveMoney(int money)
    {
        playerMoney += money;
        UpdateMoney();
    }

    public void SpendMoney(int money)
    {
        playerMoney -= money;
        UpdateMoney();
    }

    void UpdateMoney()
    {
        moneyText.text = "$" + playerMoney;
    }
}

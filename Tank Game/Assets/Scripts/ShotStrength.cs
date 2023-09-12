using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotStrength : MonoBehaviour
{
    //access tank controller script
    Tank tank;

    //store shot strength for each player (bullet speed = strength * 3)
    public int playerOneStrength = 3;
    public int playerTwoStrength = 3;

    public int maxStrength = 5;
    public int minStrength = 1;

    public Gradient gradient;

    public Slider playerOneStrengthBar;
    public Image playerOneStrengthBarColour;

    public Slider playerTwoStrengthBar;
    public Image playerTwoStrengthBarColour;

    // Start is called before the first frame update
    void Start()
    {
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();

        //set up strength bars
        playerOneStrengthBar.maxValue = maxStrength;
        playerOneStrengthBar.value = playerOneStrength;
        playerOneStrengthBarColour.color = gradient.Evaluate(playerOneStrength * 0.2f);

        playerTwoStrengthBar.maxValue = maxStrength;
        playerTwoStrengthBar.value = playerOneStrength;
        playerTwoStrengthBarColour.color = gradient.Evaluate(playerOneStrength * 0.2f);
    }

    public void playerStrengthChange(bool playerOneTurn, int change)
    {
        if (playerOneTurn)
        {
            playerOneStrength += change;
        }
        else if (!playerOneTurn)
        {
            playerTwoStrength += change;
        }
        UpdateStrengthBar();
    }

    void UpdateStrengthBar()
    {
        playerOneStrengthBarColour.color = gradient.Evaluate(playerOneStrength * 0.2f);
        playerOneStrengthBar.value = playerOneStrength;

        playerTwoStrengthBarColour.color = gradient.Evaluate(playerTwoStrength * 0.2f);
        playerTwoStrengthBar.value = playerTwoStrength;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //store iventory of different bullets
    public int Split = 0;
    public int Freeze = 0;
    public int Teleport = 0;

    //ammo type UI
    public TMP_Text ammoTypeText;

    //updates HUD to reflect chosen ammo type
    public void UpdateAmmoType(int ammoType)
    {
        if (ammoType == 1)
        {
            ammoTypeText.text = "Basic: \u221E"; //infinite basic ammo
        }
        else if (ammoType == 2)
        {
            ammoTypeText.text = "Split: " + Split;
        }
        else if (ammoType == 3)
        {
            ammoTypeText.text = "Freeze: " + Freeze;
        }
        else if (ammoType == 4)
        {
            ammoTypeText.text = "Teleport: " + Teleport;
        }
    }

    //checks if player has enough ammo to fire
    public bool CheckAmmo(int ammoType)
    {
        if (ammoType == 2 && Split > 0)
        {
            Split--;
            return true;
        }
        else if (ammoType == 3 && Freeze > 0)
        {
            Freeze--;
            return true;
        }
        else if (ammoType == 4 && Teleport > 0)
        {
            Teleport--;
            return true;
        }
        else
        {
            return false;
        }
    }
}

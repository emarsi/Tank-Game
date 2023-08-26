using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;

    public Slider healthbar;

    // Start is called before the first frame update
    void Start()
    {
        //set health to max at start
        currentHealth = maxHealth;
        
        //set slider values for UI
        healthbar.maxValue = maxHealth;
        healthbar.value = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        //update health and UI when damage taken
        currentHealth -= damage;
        healthbar.value = currentHealth;
    }
}

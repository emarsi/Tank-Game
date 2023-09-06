using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    int damage = 5;

    //access tank controller script
    Tank tank;

    //access money script
    PlayerMoney playerMoney;

    void Awake()
    {
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
        playerMoney = GameObject.Find("Tank 1").GetComponent<PlayerMoney>();
    }

    void FixedUpdate()
    {
        //applies force to bullet
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        string selfName = gameObject.name;
        
        //deal damage to target if it hits a player
        if (collisionGameObject.GetComponent<PlayerHealth>() != null)
        {
            collisionGameObject.GetComponent<PlayerHealth>().TakeDamage(damage);

            //get some money for hitting target
            playerMoney.GiveMoney(10);
        }

        //destroy self
        Destroy(gameObject);

        //set shot to inactive so players may move and swap turns
        tank.shotActive = false;
        //change turn here so money on hit goes to correct player
        tank.playerOneTurn = !tank.playerOneTurn; 
        //updates player turn indicator on HUD
        tank.UpdateTurn();

        //TODO create big explosion
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    int damage = 5;

    //access tank controller script
    Tank tank;

    void Awake()
    {
        tank = GameObject.Find("Tank 1").GetComponent<Tank>();
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
        
        //deal damage to target
        if (collisionGameObject.GetComponent<PlayerHealth>() != null)
        {
            collisionGameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }

        //destroy self
        Destroy(gameObject);

        //set shot to inactive so players may move
        tank.shotActive = false;

        //TODO create big explosion
    }
}


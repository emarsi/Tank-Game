using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;

    void FixedUpdate()
    {
        //applies force to bullet
        transform.position += transform.up * Time.deltaTime * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collisionGameObject = collision.gameObject;
        string selfName = gameObject.name;

        //destroy self
        Destroy(gameObject);

        //TODO create big explosion
    }
}


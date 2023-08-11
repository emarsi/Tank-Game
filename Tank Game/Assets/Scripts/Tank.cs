using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{

    public Transform firePoint;

    public GameObject bullet;

    public Transform gun;

    public Rigidbody2D rb;
    public Transform tank1;

    public float rotateSpeed = 1f;
    public float moveSpeed = 5f;

    Vector2 moveDir;

    float direction = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Shoot();
        }

        //player 1 turret up/down movement
        if (Input.GetKey("w"))
        {
            if (gun.transform.rotation.z < 1)
            {
                gun.transform.Rotate(0, 0, rotateSpeed, Space.Self);
            }
        }
        if (Input.GetKey("s"))
        {
            if (gun.transform.rotation.z > 0)
            {
                gun.transform.Rotate(0, 0, -1 * rotateSpeed, Space.Self);
            }
        }

        //player 1 left and right movement
        if (Input.GetKey("d"))
        {
            direction = 1;
        }
        else if (Input.GetKey("a"))
        {
            direction = -1;
        }
        else
        {
            direction = 0;
        }
    }

    void FixedUpdate()
    {
        //moves tank left and right
        moveDir = new Vector2(direction, 0);
        tank1.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
    }

    void Shoot()
    {
        //create and shoot bullet
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}

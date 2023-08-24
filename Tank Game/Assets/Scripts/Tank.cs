using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tank : MonoBehaviour
{

    public Transform firePoint1;
    public Transform firePoint2;

    public GameObject bullet;

    public Transform gun1;
    public Transform gun2;

    public Transform tank1;
    public Transform tank2;

    public float rotateSpeed = 1f;
    public float moveSpeed = 5f;

    Vector2 moveDir;

    float direction = 0;

    //track player turn
    bool playerOneTurn = true;

    public TMP_Text turnText;

    // Update is called once per frame
    void Update()
    {
        //player 1 controls
        if (playerOneTurn)
        {
            //player 1 turret up/down movement
            if (Input.GetKey("w")) //up
            {
                if (gun1.transform.rotation.z < 1)
                {
                    gun1.transform.Rotate(0, 0, rotateSpeed, Space.Self);
                }
            }
            if (Input.GetKey("s")) //down
            {
                if (gun1.transform.rotation.z > 0)
                {
                    gun1.transform.Rotate(0, 0, -1 * rotateSpeed, Space.Self);
                }
            }

            //player 1 left and right movement
            if (Input.GetKey("d")) //right
            {
                direction = 1;
            }
            else if (Input.GetKey("a")) //left
            {
                direction = -1;
            }
            else //no input
            {
                direction = 0;
            }
        }
        else if (!playerOneTurn)
        {
            //player 2 turret up/down movement
            if (Input.GetKey("k")) //down
            {
                if (gun2.transform.rotation.z < 1)
                {
                    gun2.transform.Rotate(0, 0, rotateSpeed, Space.Self);
                }
            }
            if (Input.GetKey("i")) //up
            {
                if (gun2.transform.rotation.z > 0)
                {
                    gun2.transform.Rotate(0, 0, -1 * rotateSpeed, Space.Self);
                }
            }

            //player 1 left and right movement
            if (Input.GetKey("l")) //right
            {
                direction = 1;
            }
            else if (Input.GetKey("j")) //left
            {
                direction = -1;
            }
            else //no input
            {
                direction = 0;
            }
        }

        //shoot 
        if (Input.GetKeyDown("space"))
        {
            Shoot();
            //cycle turn
            playerOneTurn = !playerOneTurn;
            UpdateTurn();
        }
    }

    void FixedUpdate()
    {
        //moves tank left and right
        moveDir = new Vector2(direction, 0);
        if (playerOneTurn)
        {
            tank1.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
        }
        else if (!playerOneTurn)
        {
            tank2.Translate(moveDir * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void Shoot()
    {
        //create and shoot bullet
        if (playerOneTurn)
        {
            Instantiate(bullet, firePoint1.position, firePoint1.rotation);
        }
        else if (!playerOneTurn)
        {
            Instantiate(bullet, firePoint2.position, firePoint2.rotation);
        }
    }

    void UpdateTurn()
    {
        if (playerOneTurn)
        {
            turnText.text = "Player 1 Turn";
        }
        else if (!playerOneTurn)
        {
            turnText.text = "Player 2 Turn";
        }
    }
}

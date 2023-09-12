using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

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

    //moveTime drops available "gas" as player moves
    float moveTime = 3f;

    public Slider playerOneGasBar;
    public Slider playerTwoGasBar;

    //track player turn
    public bool playerOneTurn = true;

    public TMP_Text turnText;

    //track if projectile is active to see if players can move yet
    public bool shotActive = false;

    //access money script
    PlayerMoney playerMoney;

    //store shot strength for each player (bullet speed = strength * 3)
    //public int playerOneStrength = 3;
    //public int playerTwoStrength = 3;

    /*
    int maxStrength = 5;
    int minStrength = 1;

    public Gradient gradient;
    public Slider playerOneStrengthBar;
    public Image playerOneStrengthBarColour;
    */

    //access script for modifying shot strength
    ShotStrength shotStrength;

    void Start()
    {
        //set gas meters
        playerOneGasBar.maxValue = moveTime;
        playerOneGasBar.value = moveTime;

        playerTwoGasBar.maxValue = moveTime;
        playerTwoGasBar.value = moveTime;

        //access money script
        playerMoney = GetComponent<PlayerMoney>();

        //shot strength script
        shotStrength = GameObject.Find("EventSystem").GetComponent<ShotStrength>();

        //set up strength bars 
        /*
        playerOneStrengthBar.maxValue = maxStrength;
        playerOneStrengthBar.value = playerOneStrength;
        playerOneStrengthBarColour.color = gradient.Evaluate(playerOneStrength * 0.2f);
        */
    }

    // Update is called once per frame
    void Update()
    {
        //players may only act if a shot is not active (must wait to see where bullet hits)
        if (!shotActive)
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

                //player needs gas left to move
                if (moveTime > 0)
                {
                    //player 1 left and right movement
                    if (Input.GetKey("d")) //right
                    {
                        direction = 1;
                        UseGas();
                    }
                    else if (Input.GetKey("a")) //left
                    {
                        direction = -1;
                        UseGas();
                    }
                    else //no input
                    {
                        direction = 0;
                    }
                }
                else //out of gas
                {
                    direction = 0;
                }
                //control shot strength
                if (Input.GetKeyDown("e")) //increase
                {
                    //ensure player cannot increase past max strength
                    if (shotStrength.playerOneStrength < shotStrength.maxStrength)
                    {
                        //playerOneStrength++;
                        //UpdateStrengthBar();

                        //send turn and value to change by
                        shotStrength.playerStrengthChange(playerOneTurn, 1);

                    }
                }
                if (Input.GetKeyDown("q")) //decrease
                {
                    //ensure player cannot decrease past min strength
                    if (shotStrength.playerOneStrength > shotStrength.minStrength)
                    {
                        //playerOneStrength--;
                        //UpdateStrengthBar();
                        shotStrength.playerStrengthChange(playerOneTurn, -1);
                    }
                }
            }
            //player 2 controls
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

                //player needs gas left to move
                if (moveTime > 0)
                {
                    //player 1 left and right movement
                    if (Input.GetKey("l")) //right
                    {
                        direction = 1;
                        UseGas();
                    }
                    else if (Input.GetKey("j")) //left
                    {
                        direction = -1;
                        UseGas();
                    }
                    else //no input
                    {
                        direction = 0;
                    }
                }
                else //out of gas
                {
                    direction = 0;
                }
                //control shot strength
                if (Input.GetKeyDown("u")) //increase
                {
                    //ensure player cannot increase past max strength
                    if (shotStrength.playerTwoStrength < shotStrength.maxStrength)
                    {
                        //playerTwoStrength++;
                        shotStrength.playerStrengthChange(playerOneTurn, 1);
                    }
                }
                if (Input.GetKeyDown("o")) //decrease
                {
                    //ensure player cannot decrease past min strength
                    if (shotStrength.playerTwoStrength > shotStrength.minStrength)
                    {
                        //playerTwoStrength--;
                        shotStrength.playerStrengthChange(playerOneTurn, -1);
                    }
                }
            }

            //shoot 
            if (Input.GetKeyDown("space"))
            {
                Shoot();

                //set gas back to full
                moveTime = 3f;
                playerOneGasBar.value = moveTime;
                playerTwoGasBar.value = moveTime;
            }
        }
        else //stop any current movement while shot is active
        {
            direction = 0;
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
        shotActive = true;

        //player gets some money for each shot
        playerMoney.GiveMoney(5);
    }

    public void UpdateTurn()
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

    void UseGas()
    {
        moveTime -= Time.deltaTime;

        //update gas meter UI
        if (playerOneTurn)
        {
            playerOneGasBar.value = moveTime;
        }
        else if (!playerOneTurn)
        {
            playerTwoGasBar.value = moveTime;
        }
    }
    /*
    void UpdateStrengthBar()
    {
        playerOneStrengthBarColour.color = gradient.Evaluate(playerOneStrength * 0.2f);
        playerOneStrengthBar.value = playerOneStrength;
    }
    */
}

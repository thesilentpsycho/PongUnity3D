using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

    [SerializeField]
    public float speed = 50;
    float height;
    public Rigidbody2D thisRigidBody;

    //string input;
    public bool isRight;

    // Use this for initialization
    void Start () {
        //height = transform.localScale.y;
        //Init(isRight);
        //speed = 5f;
    }


    public void Init(bool isRightPaddle)
    {
        Vector2 pos = Vector2.zero;
        if (isRightPaddle)
        {
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            //pos = new Vector2(-9, 0);

            //input = "PaddleRight";
        }
        else{
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            //pos = new Vector2(9, 0);

            //input = "PaddleLeft";
        }
        transform.position = pos;

        //transform.name = input;
    }

    void Update()
    {
        //Debug.Log("Checking for input");
        //float move = Input.GetAxis(input) * Time.deltaTime * speed;

        ////Restrict Movement bottom
        //if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        //{
        //    move = 0;
        //}
        ////Restrict Movement top
        //if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        //{
        //    move = 0;
        //}

        //transform.Translate(move * Vector2.up);
    }

    void FixedUpdate()
    {
        CheckForPlayerInput();
    }

    private void CheckForPlayerInput()
    {
        if (isRight)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                MovePaddleUp();
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                MovePaddleDown();
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                MovePaddleUp();
            }
            if (Input.GetKey(KeyCode.S))
            {
                MovePaddleDown();
            }
        }
    }

    private void MovePaddleDown()
    {
        float move = Time.deltaTime * speed;

        //Restrict Movement bottom
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        //Restrict Movement top
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.down);
        //transform.Translate(Time.deltaTime * speed * Vector2.up);
        //thisRigidBody.AddForce(Vector2.up * speed);
    }

    private void MovePaddleUp()
    {
        float move = Time.deltaTime * speed;

        //Restrict Movement bottom
        if (transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }
        //Restrict Movement top
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        Debug.Log(thisRigidBody);
        Debug.Log("Speed: "+ Vector2.down.ToString() + speed.ToString());
        transform.Translate(move * Vector2.up);
        //thisRigidBody.AddForce(Vector2.down * speed);
    }
}

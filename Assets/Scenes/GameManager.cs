using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Ball ball;
    public Paddle leftPaddle;
    public Paddle rightPaddle;
    public Text victoryMessage;
    public int leftPlayerLife = 0;
    public int rightPlayerLife = 0;
    public int scoreToWin = 3;
    public Text LeftHealthText;
    public Text RightHealthText;
    public static bool restartGame;

    public static Vector2 bottomLeft;
    public static Vector2 topRight;

    // Use this for initialization
    void Start () {

        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

    }

    void Update()
    {


    }

    public void UpdateScore(string player)
    {
        if (player.Equals("left"))
        {
            Debug.Log("update score called");
            leftPlayerLife += 1;
            LeftHealthText.text = "Points: " + leftPlayerLife;
        }
        else if (player.Equals("right"))
        {
            Debug.Log("update score called");
            rightPlayerLife += 1;
            RightHealthText.text = "Points: " + rightPlayerLife;
        }
        CheckIfGameIsWon();
    }

    private void CheckIfGameIsWon()
    {
        if (leftPlayerLife >= scoreToWin) HandleEndGame("left");
        else if (rightPlayerLife >= scoreToWin) HandleEndGame("right");
    }

    public void HandleEndGame(string playerWhoWon)
    {
        DisplayEndMessage(playerWhoWon);
    }

    public void DisplayEndMessage(string playerWhoWon)
    {
        string victoryMessage = "Player ";
        if(playerWhoWon == "left")
        {
            victoryMessage += "1 Won !!";
        }
        else
        {
            victoryMessage += "2 Won !!";
        }
        this.victoryMessage.text = victoryMessage;
        Time.timeScale = 0;
    }

}

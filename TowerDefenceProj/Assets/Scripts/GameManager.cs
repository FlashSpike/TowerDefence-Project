using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static bool GameIsOver;  //static variable to be called without creating an instance of a class

    public GameObject gameOverUI;
    public GameObject completeLevelUI;


    void Start()
    {
        GameIsOver = false;  //This is to prevent the beginning of each game running.
                             //Example - You lost on the last instance and now the game is over,
                             //without this code here the next instance you run will display that the game is over.
                             //This code is to reset each instances to allow the game to keep running instead of displaying the game over screen.
    }



    // Update is called once per frame
    void Update()
    {
        if (GameIsOver) //If game has already ended, return //Console Display: Game Over!
            return;

        if (Input.GetKeyDown("e")) //Game instance will alternatively End when Key "E" is pressed.
        {
            EndGame();
        }

        if (PlayerStats.Lives <= 0) //If lives is less than 0 execute next line of code
        {
            EndGame();
        }
    }
    //Game Over
    void EndGame()
    {
        GameIsOver = true;
        gameOverUI.SetActive(true);
    }

    public void WinLevel()
    {
        GameIsOver = true;
        completeLevelUI.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Attributes")]
    //Stating Money
    public static int Money;     //Public Money Variable
    public int startMoney = 200; //Starting Money

    //Stating Health
    public static int Lives;     //Public Lives Variable
    public int startLives = 20; //Starting Lives

    //Stating Round
    public static int Rounds;     //Public Rounds Variable
    public int startRounds = 0;   //Starting Rounds

    //Fixed Per Launch of the Game
    void Start()
    {
        Money = startMoney;     //The Reason why we don't set directly Money = StartMoney
                                //Static Variable will carry from 1 scene to another scene
                                //So in other to allow the player to have starting money when the game restarts,
                                //we do it this way!


        Lives = startLives;     //Same for Lives

        Rounds = startRounds;   //Same for Rounds
    }
}

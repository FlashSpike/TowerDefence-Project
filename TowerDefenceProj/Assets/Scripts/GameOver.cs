using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public string menuSceneName = "Main Menu"; //Just a variable for Main Menu so we do not hard code it

    public SceneFader sceneFader;

    //Game Restart
    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name); //Run new game instances
    }

    //Game Menu
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName); //Upon Clicking Menu Load Menu
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Level to Load
public class MainMenu : MonoBehaviour
{
    public string levelToLoad = "MainLevel"; //Load MainLevel

    public SceneFader sceneFader;

//Play Game
public void Play()
    {
        sceneFader.FadeTo(levelToLoad); //Upon Clicking Play Load Level
    }

//Quit Game
public void Quit()
    {
        Application.Quit(); //Quit
    }
}

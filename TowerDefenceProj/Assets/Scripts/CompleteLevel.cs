using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public string menuSceneName = "MainMenu"; //Just a variable for Main Menu so we do not hard code it

    public string nextLevel = "Level02";
    public int levelToUnlock = 2;

    public SceneFader sceneFader;

    public void Continue()
    {
        PlayerPrefs.SetInt("level Reached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }

    //Game Menu
    public void Menu()
    {
        sceneFader.FadeTo(menuSceneName);
    }
}

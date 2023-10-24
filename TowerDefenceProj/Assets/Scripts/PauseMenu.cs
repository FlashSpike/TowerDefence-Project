using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject ui;

    public string menuSceneName = "MainMenu"; //Just a variable for Main Menu so we do not hard code it

    public SceneFader sceneFader;

    //Toggle Pause Keybinds
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) //If Esc or P is Pressed
        {
            Toggle(); //Pause the Game
        }
    }

    //Toggle Pause
    public void Toggle()
    {
        ui.SetActive(!ui.activeSelf); //UI is Active when Keys are pressed Disable it

        if (ui.activeSelf)  //If pause is active
        {
            Time.timeScale = 0f;  //Freeze Process/Time/Game
        } 
        else 
        {
            Time.timeScale = 1f;  //To Unfreeze the Process/Time/Game
        }
    }

    //Game Restart
    public void Retry()
    {
        Toggle(); //To Unfreeze the Process/Time/Game
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
}

    //Game Menu
    public void Menu()
    {
        Toggle(); //To Unfreeze the Process/Time/Game
        sceneFader.FadeTo(menuSceneName);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    //Type Conversion
    public TextMeshProUGUI livesText;   //Making Text in TextMesh into livesText Variable
                                        //then we can convert the text below

    //Lives Display
    // Update is called once per frame
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " " + "LIVES"; //Display the Lives better for the player to see
                                                                       //it will be displayed on the canvas at the Top of the screen
    }
}

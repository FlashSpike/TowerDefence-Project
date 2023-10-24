using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    //Type Conversion
    public TextMeshProUGUI moneyText;  //Making Text in TextMesh into moneyText Variable
                                       //then we can convert the text below
    

    //Money Display
    // Update is called once per frame
    void Update()
    {
        moneyText.text = "$" + PlayerStats.Money.ToString();  //Display the Money better for the player to see
                                                              //it will be displayed on the canvas at the Bottom of the screen
    }
}

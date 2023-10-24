using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundsSurvived : MonoBehaviour
{
    //Type Conversion
    public TextMeshProUGUI roundsText;   //Making Text in TextMesh into roundsText Variable
                                         //then we can convert the text below

    //Rounds Display
    void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    IEnumerator AnimateText() //Pause between each animation
    {
        roundsText.text = "0"; //Set Text to "0"
        int round = 0;         //Create a Varaible = 0

        yield return new WaitForSeconds(0.7f); //Wait for 0.7s before starting the count (Accending Order)

        while (round < PlayerStats.Rounds) //When Round is less than Player Survival Round
        {                                  //Example if player only survived 3 rounds so it will start from 0
            round++;                       //+1
            roundsText.text = round.ToString(); //Set Text to 1 and so on till it matches Player Survived Rounds

            yield return new WaitForSeconds(0.05f); //Wait for 0.05s before going to the next number (Accending Order)
        }
    }
}

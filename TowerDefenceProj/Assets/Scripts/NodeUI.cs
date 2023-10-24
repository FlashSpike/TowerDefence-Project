using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;  //This Canves UI into GameObject

    public TextMeshProUGUI upgradeCost; //Making Text in TextMesh into upgradeCost Variable
    public TextMeshProUGUI sellAmount;  //Making Text in TextMesh into sellAmount Variable

    public Button upgradeButton;        //Making upgradeButton into a Variable
    public Button sellButton;           //Making sellButton into a Variable

    private Node target;

    //Unhide Canvas when a turret is selected
    public void SetTarget(Node _target)
    {
        target = _target;  //Creating a new value for private target.
                           //Private target is now set to a public _target
                           //Do this to prevent changes to the inital code but to this clone of it instead.

        transform.position = target.GetBuildPosition(); //To place it on where the turret is than inside the node.

        //Turret Upgrade(Only Once)
        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost; //Display the Upgrade Cost better for the player to see
                                                                         //it will be displayed on the upgrade canvas when click on a Existing Turret

            upgradeButton.interactable = true;  //Button is Pressable
        }
        else
        {
            upgradeCost.text = "MAXED";
            upgradeButton.interactable = false; //Button is NOT Pressable
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount(); //Display the Selling Amount better for the player to see
                                                                        //it will be displayed on the sell canvas when click on a Existing Turret

        ui.SetActive(true); //Canvas appear when a target node is selected. (Existing Turret on Node)
    }
    //Hide UI Canvas
    public void Hide()
    {
        ui.SetActive(false); //Canvas disappear when there is no target selected. (No Existing Turret on Node)
    }

    //Upgrade Turret
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode(); //Close the Upgrade Menu when done Upgrading
    }

    //Selling Turret
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode(); //Close the Sell Menu when done Selling
    }
}

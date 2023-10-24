using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    [Header("Attributes")]
    public Color hoverColor;            //To access in Unity Inspector to change the color
    public Color notEnoughMoneyColor;   //To access in Unity Inspector to change the color
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;  //Making the turret a variable
    [HideInInspector]
    public TurretBlueprint turretBlueprint; //Access to turret blueprints
    [HideInInspector]
    public bool isUpgraded = false; //Turrets placed are not upgraded

    [Header("Unity Setup Fields")]
    private Renderer rend;      //Give this Renderer function a name
    private Color startColor;   //Original Color

    //Reference to Build Manager
    BuildManager buildManager;      //Access to Build Manager Script

    //Default Colour
    void Start()
    {
        rend = GetComponent<Renderer>();  //This function will get the component renderer
        startColor = rend.material.color; //Setting the Default Color

        buildManager = BuildManager.instance;  //Private Build Manager = Build Manager Script instance
    }

    //Build Position (X, Y, Z)
    public Vector3 GetBuildPosition()  //Building Position On Node
    {
        return transform.position + positionOffset;
    }

    //Choosing Node & Turret to Spawn
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())  //Check Pointer == GameObject
            return;

        if (turret != null)  //If there's Turret
        {
            buildManager.SelectNode(this); //Select the Turret
            return;
        }

        if (!buildManager.CanBuild)       //Check for Avalibilities of Nodes to Build On
            return;

        BuildTurret(buildManager.GetTurretToBuild()); //Aceess to the blueprints of turrets

        buildManager.SelectTurretToBuild(null);   //Unselect Selected Turret
    }

    //Building On Nodes Requirements
    void BuildTurret(TurretBlueprint blueprint) //Building On a Node
    {
        if (PlayerStats.Money < blueprint.cost) //If player have not enough money
        {
            Debug.Log("Not enough money to build that!");  //Print "Not enough money to build that!!"
            return;
        }

        PlayerStats.Money -= blueprint.cost;    //If player have enough money minus turret cost

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity); //Selected Turret, placed on Node Position to get built, Locked rotation when placed.
        turret = _turret;  //Build Selected Turret

        //Store New Blueprints
        turretBlueprint = blueprint; //Access New Blueprints

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //Create Effect upon Successful Building
        Destroy(effect, 5f);    //Destroy Effect

        Debug.Log("Turret Build!");  //Tell the Player that the turret is built in Console
    }

    //Upgrade Turret
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost) //If player have not enough money
        {
            Debug.Log("Not enough money to upgrade that!");  //Print "Not enough money to upgrade that!"
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;    //If player have enough money minus turret cost

        //Get rid of Old Turret
        Destroy(turret);  //Destroy the Turret before Upgrading to prevent duplicates of turret

        //Building a New Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity); //Selected Turret, placed on Node Position to get built, Locked rotation when placed.
        turret = _turret;  //Build Selected Turret

        GameObject effect = (GameObject)Instantiate(buildManager.buildEffect, GetBuildPosition(), Quaternion.identity); //Create Effect upon Successful Building
        Destroy(effect, 5f); //Destroy Effect

        isUpgraded = true;

        Debug.Log("Turret Upgraded!");  //Tell the Player that the turret is upgraded in Console
    }

    //Sell Turret
    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount(); //Upon pressing Sell Button Get an Amount of money back

        //Spawn a cool effect
        GameObject effect = (GameObject)Instantiate(buildManager.sellEffect, GetBuildPosition(), Quaternion.identity); //Create Effect upon Successful Selling
        Destroy(effect, 5f); //Destroy Effect

        Destroy(turret);  //Destroy the Turret Upon pressing the Sell Button
        turretBlueprint = null; //To prevent errors of this function passing in to the turret blueprint
    }



    //Entering Node Hovering Animation
    void OnMouseEnter()    
    {
        if (EventSystem.current.IsPointerOverGameObject())  //Check Pointer == GameObject
            return;

        if (!buildManager.CanBuild)        //Check for Avalibilities of Nodes to Build On
            return;

        if (buildManager.HasMoney) //if Player have enough money or more to purchase the turret
        {
            rend.material.color = hoverColor; //Creating a hover color animation for sufficient or more balance, everytime the mouse passes by or enter the nodes colliders, this function will be called and it will change colors to Black.
        }
        else //if Player does not have enough money to purchase the turret
        {
            rend.material.color = notEnoughMoneyColor; //Creating a hover color animation for not sufficient balance, everytime the mouse passes by or enter the nodes colliders, this function will be called and it will change color to Red.
        }   
        
    }

    //Exiting Node
    void OnMouseExit()
    {
        rend.material.color = startColor; //When the mouse leaves the colliders return to Default Color
    }
}

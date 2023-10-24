using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;     //Singleton Pattern, Stores reference to itself, Accessable From Anywhere
                                             //Only 1 Instance Run at a time, , so if there's more than 1 Instance of Build Manager, the other will idle.
    void Awake()
    {
        if (instance != null)                //To check for instances of mutiple Build Managers in Scene.
        {
            Debug.LogError("More than 1 BuildManager in Scene!");
            return;
        }
                                             //We Only Want 1 Build Manager
        instance = this;                     //Instance = THIS Build Manager
    }

    //Types of Turret
    public GameObject standardTurretPrefab;  //Standard Turret
    public GameObject missileLauncherPrefab; //Missile Launcher
    public GameObject otherTurretPrefab;     //Other Turret

    //Effects
    //Building Effects
    public GameObject buildEffect;
    //Selling Effects
    public GameObject sellEffect;

    //Build Turret
    private TurretBlueprint turretToBuild;   //Access to turret to build blueprints

    //Upgrade or Sell onto Existing Turret on Node
    private Node selectedNode;               //Selected Node

    //NodeUI UI Canvas (Upgrade/Sell) Pannel
    public NodeUI nodeUI;                    //NodeUI UI Canvas

    //Building Turrets on Nodes
    public bool CanBuild { get { return turretToBuild != null;} } //Property, Basically finding true or false for CanBuild function,
                                                                  //How it works, if we use CanBuild function, if we can build it will check if it is not equal to null,
                                                                  //if it is true we can build, false we cannot build

    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } } //If we do not have enough money to build the turret it will return false, if we do have enough or more it will return true.
                                                                                     //Not sufficient = False, Sufficient or more = True

    //Build on Selected Node
    public void SelectNode(Node node) //Build on Selected Node
    {
        //Toggling NodeUI UI Canvas (Upgrade/Sell) Pannel
        if (selectedNode == node)   //If node selected with existing turret,
        {                           
            DeselectNode();         //Deselect the Node
            return;
        }

        selectedNode = node;       //Build onto an existing Turret
        turretToBuild = null;      //But do not build a turret

        nodeUI.SetTarget(node);    //Targeting the Node that has a built Turret
    }

    //Hiding NodeUI UI Canvas (Upgrade/Sell) Pannel
    public void DeselectNode()     //Unselect Existing Turret node
    {
        selectedNode = null;       //If nothing is selected, hide NodeUI UI Canvas
        nodeUI.Hide();
    }

    //Build Selected Turret
    public void SelectTurretToBuild(TurretBlueprint turret)  
    {
        turretToBuild = turret;    //Build Selected Turret
        DeselectNode();            //Hide NodeUI Canves when building Selected Turrets
    }

    //Alternative Access to turret to build blueprint
    public TurretBlueprint GetTurretToBuild() //Since this is not the main private function,
                                              //data that we change will only affect this function.
    {
        return turretToBuild;
    }
}

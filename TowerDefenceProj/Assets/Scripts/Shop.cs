using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    //Reference to TurretBlueprint
    public TurretBlueprint standardTurret;         //Access from Turret Blueprint Script
    public TurretBlueprint missileLauncher;          //Access from Turret Blueprint Script
    public TurretBlueprint otherTurret;            //Access from Turret Blueprint Script

    //Reference to Build Manager
    BuildManager buildManager;      //Access to Build Manager Script

    void Start()
    {
        buildManager = BuildManager.instance;  //Private Build Manager = Build Manager Script instance
    }

    //Select Standard Turret
    public void SelectStandardTurret()
    {
        Debug.Log ("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret); //Upon clicking Build Standard Turret
    
    }

    //Purchase Missile Launcher
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManager.SelectTurretToBuild(missileLauncher); //Upon clicking Build Missile Launcher
    }

    //Purchase Other Turret
    public void SelectOtherTurret()
    {
        Debug.Log("Other Turret Selected");
        buildManager.SelectTurretToBuild(otherTurret);   //Upon clicking Build Other Turret
    }
}

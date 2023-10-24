using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]         //Save and Show Data in Unity Inspector
public class TurretBlueprint
{
    public GameObject prefab; //Prefab of Turrets

    public int cost;  //Configure Cost of turrets in Unity inspector

    public GameObject upgradedPrefab; //Prefab of Upgraded Turrets

    public int upgradeCost;  //Configure Upgraded Cost of turrets in Unity inspector

    //Cash Earned froom Selling Turret 
    public int GetSellAmount() //Money earned from Selling Turret
    {
        return cost / 2;
    }
}

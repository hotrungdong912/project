using System;
using System.Collections;
using UnityEngine;


[System.Serializable]
public class TurretBlueSpint
{
    public GameObject prefab; 
    public int cost;

    public GameObject upgradePrefab;
    public int upgradeCost;

    public GameObject upgrade2Prefab;
    public int upgrade2Cost;

    public GameObject upgrade3Prefab;
    public int upgrade3Cost;

    public int GetsellAmount(int a)
    {
        return Convert.ToInt32(a / 3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Shop : MonoBehaviour
{
    public TurretBlueSpint archertower;
    public TurretBlueSpint ballisatower;
    public TurretBlueSpint CannonTower;
    public TurretBlueSpint PoisonTower;
    public TurretBlueSpint WizardTower;
    BuildManager buildManager;
     void Start()
    {
        buildManager = BuildManager.intance;
    }

    
    public void SelectArchertower()
    {
        //Debug.Log("Archertower Selected");
        buildManager.SelectTurretToBuild(archertower);
    }
    public void SelectBallisatower()
    {
        //Debug.Log("Ballisatower Selected");
        buildManager.SelectTurretToBuild(ballisatower);
    }
    public void SelectCannonTower()
    {
        //Debug.Log("CannonTower Selected");
        buildManager.SelectTurretToBuild(CannonTower);
        
    }
    public void SelectPoisonTower()
    {
        //Debug.Log("PoisonTower Selected");
        buildManager.SelectTurretToBuild(PoisonTower);

    }

    public void SelectWizardTower()
    {
        //Debug.Log("WizardTower Selected");
        buildManager.SelectTurretToBuild(WizardTower);

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hovercolor;

    public Vector3 posisionOffset;
    public Color notEnoughMoneyColor;


    private Color startColor;
    private Renderer rend;

    BuildManager buildManager;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueSpint turretBlueSpint;
    [HideInInspector]

    public bool isUpgrade = false;
    public bool isUpgrade2 = false;
    public bool isUpgrade3 = false;

    public bool isUpgraded = false;
    public bool isUpgraded2 = false;
    public bool isUpgraded3 = false;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.intance;
    }
    public Vector3 GetBuildPosion()
    {
        return transform.position + posisionOffset;
    }
    public Vector3 GetBuildPosion2()
    {
        return transform.position ;
    }
    void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }     
        if(turret != null)
        {
            buildManager.Selectednode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        BuildTurred(buildManager.GetTurretToBuild());
    }
    void BuildTurred(TurretBlueSpint blueSpint)
    {
        if (PlayerStart.Money < blueSpint.cost)
        {
            Debug.Log("no enough money");
            return;
        }
        PlayerStart.Money -= blueSpint.cost;
        
        GameObject _turret = (GameObject)Instantiate(blueSpint.prefab, GetBuildPosion(), Quaternion.identity);        
        turret = _turret;

        turretBlueSpint = blueSpint;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosion(), Quaternion.identity);

        Destroy(effect, 5f);

    }
   
    public void UpgradeTurret()
    {
        if (PlayerStart.Money < turretBlueSpint.upgradeCost)
        {
            Debug.Log("no enough money to upgrade");
            return;
        }       
        PlayerStart.Money -= turretBlueSpint.upgradeCost;
        //Get rid of old turret
        Destroy(turret);

        //Build new Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueSpint.upgradePrefab, GetBuildPosion(), Quaternion.identity);
       
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosion(), Quaternion.identity);

        Destroy(effect, 5f);
        
        isUpgraded = true;
    }
    public void UpgradeTurret2()
    {
        
        if (PlayerStart.Money < turretBlueSpint.upgrade2Cost)
        {
            Debug.Log("no enough money to upgrade");
            return;
        }        
        PlayerStart.Money  -= (turretBlueSpint.upgradeCost-100) ;      
        //Get rid of old turret
        Destroy(turret);

        //Build new Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueSpint.upgrade2Prefab, GetBuildPosion(), Quaternion.identity);

        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosion(), Quaternion.identity);

        Destroy(effect, 5f);
        isUpgraded2 = true;
    }
    public void UpgradeTurret3()
    {
        if (PlayerStart.Money < turretBlueSpint.upgrade3Cost)
        {
            Debug.Log("no enough money to upgrade");
            return;
        }
        PlayerStart.Money -= (turretBlueSpint.upgrade3Cost-500);

        //Get rid of old turret
        Destroy(turret);

        //Build new Turret
        GameObject _turret = (GameObject)Instantiate(turretBlueSpint.upgrade3Prefab, GetBuildPosion(), Quaternion.identity);

        turret = _turret;

        GameObject effect = (GameObject)Instantiate(buildManager.BuildEffect, GetBuildPosion(), Quaternion.identity);

        Destroy(effect, 5f);
        isUpgraded3 = true;
    }
    public void sellTurret()
    {
        isUpgrade = true;
        if (isUpgrade == true)
        {
            PlayerStart.Money += turretBlueSpint.GetsellAmount(turretBlueSpint.cost);
  
            BuildManager.intance.DeselectNode();
            if (isUpgrade2 == true && isUpgraded == true)
            {
                PlayerStart.Money += turretBlueSpint.GetsellAmount(turretBlueSpint.upgrade2Cost);
                BuildManager.intance.DeselectNode();
                if (isUpgrade3 == true)
                {
                    PlayerStart.Money += turretBlueSpint.GetsellAmount(turretBlueSpint.upgrade3Cost);
                    PlayerStart.Money += 1;
                    BuildManager.intance.DeselectNode();
                }
            }
        }

        Destroy(turret);

        GameObject effect = (GameObject)Instantiate(buildManager.SellEffect, GetBuildPosion(), Quaternion.identity);

        Destroy(effect, 5f);

        turretBlueSpint = null;

    }

    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if (buildManager.HasMoney)
        {
            rend.material.color = hovercolor;
        }else
        {
            rend.material.color = notEnoughMoneyColor;
        }

    }
    void OnMouseExit()
    {
        rend.material.color = startColor;
    }
   
}

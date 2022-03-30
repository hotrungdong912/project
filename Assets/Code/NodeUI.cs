using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;
    private Node target;

    public Text SellAmount;

    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosion();

        if (target.isUpgrade == false)
        {
            upgradeCost.text = "$" + target.turretBlueSpint.upgradeCost;
            upgradeButton.interactable = true;
            Debug.Log("da hien up ");///////////////////////////////////////////// 
            SellAmount.text = "$" + target.turretBlueSpint.GetsellAmount(target.turretBlueSpint.cost);
        }
        else if (target.isUpgraded == true )
        {
            upgradeCost.text = "$" + target.turretBlueSpint.upgrade2Cost;
            upgradeButton.interactable = true;
            Debug.Log("da hien up 1");/////////////////////////////////////////////
            target.isUpgrade2 = true;
            SellAmount.text = "$" + target.turretBlueSpint.GetsellAmount(target.turretBlueSpint.upgrade2Cost + target.turretBlueSpint.cost);
            if (target.isUpgraded2 == true && target.isUpgrade2 == true)
            {
                upgradeCost.text = "$" + target.turretBlueSpint.upgrade3Cost;
                upgradeButton.interactable = true;
                Debug.Log("da hien up 2");
                target.isUpgrade3 = true;
                if(target.isUpgraded3==true)
                {
                    upgradeCost.text = "Done";
                    upgradeButton.interactable = false;
                }

                SellAmount.text = "$" + target.turretBlueSpint.GetsellAmount(target.turretBlueSpint.upgrade2Cost + target.turretBlueSpint.cost+ target.turretBlueSpint.upgrade3Cost );
            }
            
        }      
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.isUpgrade = true;
        if (target.isUpgrade == true)
        {
            target.UpgradeTurret();
            BuildManager.intance.DeselectNode();
            if (target.isUpgrade2 == true && target.isUpgraded == true )
            {  
                target.UpgradeTurret2();
                BuildManager.intance.DeselectNode();
                Debug.Log("yeu cau up lv2");
                if (target.isUpgrade3 == true)
                {
                    target.UpgradeTurret3();
                    BuildManager.intance.DeselectNode();
                    Debug.Log("yeu cau up lv3");
                }
            }
        }
            
    } 
    public void Sell()
    {     
        target.sellTurret();
        BuildManager.intance.DeselectNode();
           
        Debug.Log("sell ");

        target.isUpgrade = false;
        target.isUpgrade2 = false;
        target.isUpgrade3 = false;

        target.isUpgraded = false;
        target.isUpgraded2 = false;
        target.isUpgraded3 = false;
    }
}

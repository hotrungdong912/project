using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager intance;


    void Awake()
    {
        if(intance != null)
        {
            Debug.LogError("More than one");
        }
        intance = this;
    }


    private TurretBlueSpint turretToBuild;
    private Node seletedNode;

    public NodeUI nodeUI;
    public bool CanBuild { get { return turretToBuild != null;  } }
    public bool HasMoney { get { return PlayerStart.Money >= turretToBuild.cost; } }

    public GameObject BuildEffect;
    public GameObject SellEffect;

    public void Selectednode(Node node)
    {
        if(seletedNode == node)
        {
            DeselectNode();
            return;
        }
        seletedNode = node;
        turretToBuild = null;

        nodeUI.setTarget(node);
    }
    public void DeselectNode()
    {
        seletedNode = null;
        nodeUI.Hide();
    }
    public void SelectTurretToBuild(TurretBlueSpint turret)
    {
       
        turretToBuild = turret;
        DeselectNode();
    }

    public TurretBlueSpint GetTurretToBuild()
    {
        return turretToBuild;
    }

}

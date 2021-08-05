using UnityEngine;

public class BuildManager : MonoBehaviour
{
   
    public static BuildManager instance;
    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public NodeUI nodeUI;
    public bool CanBuild() { { return turretToBuild != null; } }
    public bool HasMoney() { { return PlayerStats.money >= turretToBuild.cost; } }
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buldingmanager");
            return;
        }
        instance = this;
    }
    
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        selectedNode = null;

        nodeUI.Hide();
    }
    
    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
       

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurrettoBuild()
    {
        return turretToBuild;
    }
}

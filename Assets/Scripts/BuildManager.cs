using UnityEngine;

public class BuildManager : MonoBehaviour
{
   //private GameObject turretToBuild;

   // public GameObject standartTurretPrefab;
    public static BuildManager instance;
    //public GameObject missleLauncherTurretPrefab;
    private TurretBlueprint turretToBuild;


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
    public void BuildTurretOn(Node node)
    {
        if (PlayerStats.money < turretToBuild.cost)
        {
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBildPosotion(), Quaternion.identity);
        node.turret = turret;
    }
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
   
}

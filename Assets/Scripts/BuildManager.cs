using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;

    public GameObject standartTurretPrefab;
    public static BuildManager instance;
    public GameObject missleLauncherTurretPrefab;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buldingmanager");
            return;
        }
        instance = this;
    }
    
    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

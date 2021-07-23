using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void PusrchaseStandartTurret()
    {
        buildManager.SetTurretToBuild(buildManager.standartTurretPrefab);
    }
    public void PusrchaseMissleLauncherTurret()
    {
        buildManager.SetTurretToBuild(buildManager.missleLauncherTurretPrefab);
    }
}

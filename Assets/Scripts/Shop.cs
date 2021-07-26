using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standartTurret;
    public TurretBlueprint missleLauncher;
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandartTurret()
    {
        buildManager.SelectTurretToBuild(standartTurret);
    }
    public void SelectMissleLauncherTurret()
    {
        buildManager.SelectTurretToBuild(missleLauncher);
    }
}

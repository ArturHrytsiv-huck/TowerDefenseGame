using UnityEngine;

public class BuildManager : MonoBehaviour
{
    private GameObject turretToBuild;

    public GameObject standartTurretPrefab;
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one Buldingmanager");
            return;
        }
        instance = this;
    }
    private void Start()
    {
        turretToBuild = standartTurretPrefab;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}

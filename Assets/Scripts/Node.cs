using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public GameObject turret;

    [SerializeField] private Vector3 positionOffset;
    
    private Renderer rend;
    private Color startColor;
    private BuildManager buildManager;

    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }
    public Vector3 GetBildPosotion()
    {
        return transform.position + positionOffset;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            //Debug.Log("Can`t build!");
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild())
        {
            return;
        }

        //Build a turret
        BuildTurret(buildManager.GetTurrettoBuild());
    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.money < blueprint.cost)
        {
            return;
        }

        PlayerStats.money -= blueprint.cost;
        GameObject _turret = Instantiate(blueprint.prefab, GetBildPosotion(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;
    }
    public void UpgaradeTurret()
    {
        if (PlayerStats.money < turretBlueprint.upgradeCost)
        {
            Debug.Log("Not enought money");
            return;
        }

        PlayerStats.money -= turretBlueprint.upgradeCost;

        //Get riad of the old turret
        Destroy(turret);

        //Instantiate new upgraded turret
        GameObject _turret = Instantiate(turretBlueprint.upgradedPrefab, GetBildPosotion(), Quaternion.identity);
        turret = _turret;

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStats.money += turretBlueprint.GetSellAmount();

        Destroy(turret);

        turretBlueprint = null;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild())
        {
            return;
        }
        if (buildManager.HasMoney())
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = Color.red;
        }

        //rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

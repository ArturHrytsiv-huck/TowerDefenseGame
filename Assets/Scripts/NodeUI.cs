using UnityEngine.UI;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;

    public Text upgradeCost;
    public Button upgradeButton;
    public Text sellAmount;
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBildPosotion();

        if (!target.isUpgraded)
        {
            upgradeCost.text = "$" + target.turretBlueprint.upgradeCost;
            
        }
        else
        {
            upgradeCost.text = "MAX";
            upgradeButton.interactable = false;
        }

        sellAmount.text = "$" + target.turretBlueprint.GetSellAmount();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade()
    {
        target.UpgaradeTurret();
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}

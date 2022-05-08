using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretUI : MonoBehaviour
{
    [Header("UI")]
    public Text towerName;
    public Text towerDescription;
    public Button upgradeButton;
    public Button sellButton;
    public Text upgradeCost;
    public Text sellCost;

    [Header("Data")]
    public Data_Turret turretData;

    private Node node;

    private float offset = 150f;

    public void Show(Node node)
    {
        BuildManager.instance.OnChangeMoney += UpdateUI;
        
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
        this.node = node;
        turretData = node.turret.data;
        towerName.text = turretData.name;
        towerDescription.text = turretData.Description;
        upgradeCost.text = turretData.Cost.ToString();
        sellCost.text = turretData.Sell.ToString();

        Vector3 point = Camera.main.WorldToScreenPoint(node.transform.position);
        if (point.x > Screen.width / 2)
            point.x -= offset;
        else
            point.x += offset;
        point.z = 0;
        transform.position = point;

        UpdateUI();
    }

    public void Hide()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }

        BuildManager.instance.OnChangeMoney -= UpdateUI;
    }

    public void UpdateUI()
    {
        if (upgradeButton.IsActive())
            upgradeButton.interactable = BuildManager.instance.money >= turretData.Cost;
    }
}

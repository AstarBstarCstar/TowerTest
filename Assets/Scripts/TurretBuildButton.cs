using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretBuildButton : MonoBehaviour
{
    public Data_Turret data;

    public Image turretIcon;
    public Text buttonText;
    public Button buyButton;

    private void Awake() 
    {
        turretIcon.sprite = data.Icon;
        buttonText.text = data.Cost.ToString();
    }

    private void OnEnable() 
    {
        BuildManager.instance.OnChangeMoney += UpdateButton;
        UpdateButton();
    }

    private void OnDisable() 
    {
        BuildManager.instance.OnChangeMoney -= UpdateButton;
    }

    public void OnClick()
    {
        BuildManager.instance.selectedTurret = data.Prefab;
    }

    public void UpdateButton()
    {
        buyButton.interactable = BuildManager.instance.money >= data.Cost;
    }
}

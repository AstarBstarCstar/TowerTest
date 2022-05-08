using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance { get; private set; }

    public UnityAction OnChangeMoney;

    [Header("UI")]
    public GameObject buildBar;
    public TurretBuildButton buildButtonPrefab;
    public Text moneyText;
    public TurretUI turretBar;

    [Header("Turret")]
    public Data_Turret[] turretDatas;

    [Header("Build Info")]
    public Turret selectedTurret;
    public int startMoney = 200;
    private int _money;
    public int money {
        get
        {
            return _money;
        }
        private set
        {
            _money = value;
            OnChangeMoney?.Invoke();
            moneyText.text = _money.ToString();
        }
    }

    public bool CanBuild { get { return selectedTurret != null;} }
    public bool HasMoney { get { return money > selectedTurret.data.Cost;} }

    private void Awake() {
        instance = this;
    }

    private void Start() {
        foreach(Data_Turret data in turretDatas)
        {
            TurretBuildButton button = Instantiate(buildButtonPrefab);
            button.transform.SetParent(buildBar.transform);
        }
        
        money = startMoney;
    }

    public void BuildTurretOn(Node node)
    {
        if (money < selectedTurret.data.Cost)
            return;

        money -= selectedTurret.data.Cost;

        Turret turret = Instantiate(selectedTurret, node.GetBuildPosition(), Quaternion.identity);
		node.turret = turret;
    }
}

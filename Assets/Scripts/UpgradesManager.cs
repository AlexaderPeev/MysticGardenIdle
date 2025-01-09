using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;
using UnityEngine.UI;

public class UpgradesManager : MonoBehaviour
{
    public static UpgradesManager instance;
    private void Awake()
    {
        instance = this;
    }

    public List<Upgrades> ClickUpgrades;
    public Upgrades ClickUpradePrefab;

    public List<Upgrades> ProductionUpgrades;
    public Upgrades ProductionUpgradePrefab;

    public ScrollRect ClickUpgradesScroll;
    public Transform ClickUpgradesPanel;

    public ScrollRect ProductionUpgradesScroll;
    public Transform ProductionUpgradesPanel;

    public string[] ClickUpgradeNames;
    public string[] ProductionUpgradeNames;

    public BigDouble[] ClickUpgradeBaseCost;
    public BigDouble[] ClickUpgradeCostMult;
    public BigDouble[] ClickUpgradesBasePower;

    public BigDouble[] ProductionUpgradeBaseCost;
    public BigDouble[] ProductionUpgradeCostMult;
    public BigDouble[] ProductionUpgradesBasePower;

    public void StartUpgradeManager()
    {
        ClickUpgradeNames = new[] { "Click Power +1", "Click Power +5", "Click Power +10", "Click Power +25" };
        ProductionUpgradeNames = new[]
        {
            "+1 leaf/s",
            "+2 leaves/s",
            "+10 leaves/s",
            "+100 leaves/s",
        };

        ClickUpgradeBaseCost = new BigDouble[] { 10, 50, 100, 1000};
        ClickUpgradeCostMult = new BigDouble[] { 1.25, 1.35, 1.55, 2};
        ClickUpgradesBasePower = new BigDouble[] { 1, 5, 10, 25};

        ProductionUpgradeBaseCost = new BigDouble[] { 25, 100, 1000, 10000};
        ProductionUpgradeCostMult = new BigDouble[] { 1.5, 1.75, 2, 3};
        ProductionUpgradesBasePower = new BigDouble[] { 1, 2, 10, 100};

        for (int i = 0; i < Controller.instance.data.ClickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(ClickUpradePrefab, ClickUpgradesPanel);
            upgrade.UpgradeId = i;
            ClickUpgrades.Add(upgrade);
        }

        for (int i = 0; i < Controller.instance.data.ProductionUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(ProductionUpgradePrefab, ProductionUpgradesPanel);
            upgrade.UpgradeId = i;
            ProductionUpgrades.Add(upgrade);    
        }

        ClickUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        ProductionUpgradesScroll.normalizedPosition = new Vector2(0, 0);

        UpdateUpgradeUI("click");
        UpdateUpgradeUI("Production");
    }


    public void UpdateUpgradeUI(string type, int UpgradeId = -1)
    {
        var data = Controller.instance.data;

        switch (type)
        {
            case "click":
                if (UpgradeId == -1)
                {
                    for (int i = 0; i < ClickUpgrades.Count; i++)
                    {
                        UpdateUI(ClickUpgrades, data.ClickUpgradeLevel, ClickUpgradeNames, i);
                    }
                }
                else
                {
                    UpdateUI(ClickUpgrades, data.ClickUpgradeLevel, ClickUpgradeNames, UpgradeId);
                }
                break;
            case "production":
                if (UpgradeId == -1)
                {
                    for (int i = 0; i < ProductionUpgrades.Count; i++)
                    {
                        UpdateUI(ProductionUpgrades, data.ProductionUpgradeLevel, ProductionUpgradeNames, i);
                    }
                }
                else
                {
                    UpdateUI(ProductionUpgrades, data.ProductionUpgradeLevel, ProductionUpgradeNames, UpgradeId);
                }
                break;
        }

        
        void UpdateUI(List<Upgrades> upgrades, List<int> UpgradeLevels, string[] UpgradeNames, int ID)
        {
            upgrades[ID].LevelText.text = UpgradeLevels[ID].ToString();
            upgrades[ID].CostText.text = $"Cost: {UpgradeCost(type, ID):F0} Leaves";
            upgrades[ID].NameText.text = UpgradeNames[ID];
        }
    }

    public BigDouble UpgradeCost(string type, int UpgradeId)
    {
        var data = Controller.instance.data;
        switch (type)
        {
            case "click":
                return ClickUpgradeBaseCost[UpgradeId] * BigDouble.Pow(ClickUpgradeCostMult[UpgradeId], data.ClickUpgradeLevel[UpgradeId]);
            case "production":
                return ProductionUpgradeBaseCost[UpgradeId] * BigDouble.Pow(ProductionUpgradeCostMult[UpgradeId], data.ProductionUpgradeLevel[UpgradeId]);
        }
        return 0;
        
    }

    public void BuyUpgrade(string type, int UpgradeId)
    {
        var data = Controller.instance.data;
        
        switch (type)
        {
            case "click": Buy(data.ClickUpgradeLevel);
                    break;
            case "production":
                Buy(data.ProductionUpgradeLevel);
                    break;
        }

        void Buy(List<int> upgradelevels)
        {
            if (data.leaves >= UpgradeCost(type, UpgradeId))
            {
                data.leaves -= UpgradeCost(type, UpgradeId);
                upgradelevels[UpgradeId] += 1;
            }
            UpdateUpgradeUI(type, UpgradeId);
        }
    }
}

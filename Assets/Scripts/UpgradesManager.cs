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

    public ScrollRect ClickUpgradesScroll;
    public Transform ClickUpgradesPanel;

    public string[] ClickUpgradeNames;

    public BigDouble[] ClickUpgradeBaseCost;
    public BigDouble[] ClickUpgradeCostMult;
    public BigDouble[] ClickUpgradesBasePower;

    public void StartUpgradeManager()
    {
        ClickUpgradeNames = new[] { "Click Power +1", "Click Power +5", "Click Power +10" };
        ClickUpgradeBaseCost = new BigDouble[] { 10, 50, 100 };
        ClickUpgradeCostMult = new BigDouble[] { 1.25, 1.35, 1.55 };
        ClickUpgradesBasePower = new BigDouble[] { 1, 5, 10 };

        for(int i = 0; i < Controller.instance.data.ClickUpgradeLevel.Count; i++)
        {
            Upgrades upgrade = Instantiate(ClickUpradePrefab, ClickUpgradesPanel);
            upgrade.UpgradeId = i;
            ClickUpgrades.Add(upgrade);
        }
        ClickUpgradesScroll.normalizedPosition = new Vector2(0, 0);
        UpdateClickUpgradeUI();
    }


    public void UpdateClickUpgradeUI(int UpgradeId = -1)
    {
        var data = Controller.instance.data;
        if(UpgradeId == -1)
        {
            for(int i = 0; i < ClickUpgrades.Count; i++)
            {
                UpdateUI(i);
            }
        }
        else
        {
            UpdateUI(UpgradeId);
        }
        
        void UpdateUI(int ID)
        {
            ClickUpgrades[ID].LevelText.text = data.ClickUpgradeLevel[ID].ToString();
            ClickUpgrades[ID].CostText.text = $"Cost: {ClickUpgradeCost(ID):F2} Leaves";
            ClickUpgrades[ID].NameText.text = ClickUpgradeNames[ID];
        }
    }

    public BigDouble ClickUpgradeCost(int UpgradeId)
    {
        return ClickUpgradeBaseCost[UpgradeId] * BigDouble.Pow(ClickUpgradeCostMult[UpgradeId], Controller.instance.data.ClickUpgradeLevel[UpgradeId]);
    }

    public void BuyUpgrade(int UpgradeId)
    {
        var data = Controller.instance.data;
        if (data.leaves >= ClickUpgradeCost(UpgradeId))
        {
            data.leaves -= ClickUpgradeCost(UpgradeId);
            data.ClickUpgradeLevel[UpgradeId] += 1;
        }
        UpdateClickUpgradeUI(UpgradeId);
    }
}

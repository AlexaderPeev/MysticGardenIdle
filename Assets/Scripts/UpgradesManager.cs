using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BreakInfinity;

public class UpgradesManager : MonoBehaviour
{
    public Controller controller;

    public Upgrades ClickUprade;

    public string ClickUpgradeName;

    public BigDouble ClickUpgradeBaseCost;
    public BigDouble ClickUpgradeCostMult;

    public void StartUpgradeManager()
    {
        ClickUpgradeName = "Leaves per click";
        ClickUpgradeBaseCost = 10;
        ClickUpgradeCostMult = 1.5;
        UpdateClickUpgradeUI();
    }


    public void UpdateClickUpgradeUI()
    {
        ClickUprade.LevelText.text = controller.data.ClickUpgradeLevel.ToString();
        ClickUprade.CostText.text = "Cost: " + Cost().ToString("F2") + " Leaves";
        ClickUprade.NameText.text = "+1 " + ClickUpgradeName;
    }

    public BigDouble Cost()
    {
        return ClickUpgradeBaseCost * BigDouble.Pow(ClickUpgradeCostMult, controller.data.ClickUpgradeLevel);
    }

    public void BuyUpgrade()
    {
        if (controller.data.leaves >= Cost())
        {
            controller.data.leaves -= Cost();
            controller.data.ClickUpgradeLevel += 1;
        }
        UpdateClickUpgradeUI();
    }
}

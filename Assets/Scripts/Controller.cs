using UnityEngine;
using TMPro;
using BreakInfinity;
using System;

public class Controller : MonoBehaviour
{
    public static Controller instance;
    private void Awake()
    {
        instance = this;
    }

    public Data data;

    [SerializeField] public TMP_Text leavesText;
    [SerializeField] private TMP_Text LeavesPerSecondText;
    [SerializeField] private TMP_Text LeavesClickPowerText;

    public BigDouble ClickPower()
    {
        BigDouble total = 1;
        for(int i = 0; i < data.ClickUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.ClickUpgradesBasePower[i] * data.ClickUpgradeLevel[i];
        }

        return total;
    }

    public BigDouble LeavesPerSecond()
    {
        BigDouble total = 0;
        for (int i = 0; i < data.ProductionUpgradeLevel.Count; i++)
        {
            total += UpgradesManager.instance.ProductionUpgradesBasePower[i] * data.ProductionUpgradeLevel[i];
        }

        return total;
    }
    private void Start()
    {
        data = new Data();
        UpgradesManager.instance.StartUpgradeManager();
    }

    private void Update()
    {
        LeavesClickPowerText.text = "+" + ClickPower() + " Leaves";
        LeavesPerSecondText.text = $"{LeavesPerSecond():F2}/s";
        leavesText.text = $"{data.leaves:F0} Leaves";

        data.leaves += LeavesPerSecond() * Time.deltaTime;
    }

    public void GenerateLeaves()
    {
        data.leaves += ClickPower();
    }

    public static implicit operator Controller(UpgradesManager v)
    {
        throw new NotImplementedException();
    }
}

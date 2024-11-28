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
    private void Start()
    {
        data = new Data();
        UpgradesManager.instance.StartUpgradeManager();
    }

    private void Update()
    {
        LeavesClickPowerText.text = "+" + ClickPower() + " Leaves";
        leavesText.text = data.leaves + " Leaves";
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

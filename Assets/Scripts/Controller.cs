using UnityEngine;
using TMPro;
using BreakInfinity;

public class Controller : MonoBehaviour
{
    public UpgradesManager upgradesManager;
    public Data data;

    [SerializeField] public TMP_Text leavesText;

    [SerializeField] private TMP_Text LeavesClickPowerText;

    public BigDouble ClickPower()
    {
        return 1 + data.ClickUpgradeLevel;
    }
    private void Start()
    {
        data = new Data();
        upgradesManager.StartUpgradeManager();
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
}

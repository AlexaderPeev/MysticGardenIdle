using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Upgrades : MonoBehaviour
{
    public int UpgradeId;
    public Image UpgradeButton;
    public TMP_Text LevelText;
    public TMP_Text NameText;
    public TMP_Text CostText;

    public void BuyClickUpgrade()
    {
        UpgradesManager.instance.BuyUpgrade("click", UpgradeId);
    }
    public void BuyProductionUpgrade()
    {
        UpgradesManager.instance.BuyUpgrade("production", UpgradeId);
    }
}

using System.Collections;
using System.Linq;
using System.Collections.Generic;
using BreakInfinity;
public class Data
{
    public BigDouble leaves;

    public List<int> ClickUpgradeLevel;
    public List<int> ProductionUpgradeLevel;

    public Data() 
    {
        leaves = 0;

        ClickUpgradeLevel = new int[4].ToList();
        ProductionUpgradeLevel = new int[4].ToList();
    }
}

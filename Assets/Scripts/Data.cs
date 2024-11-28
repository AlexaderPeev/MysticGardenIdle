using System.Collections;
using System.Collections.Generic;
using BreakInfinity;
public class Data
{
    public BigDouble leaves;

    public List<BigDouble> ClickUpgradeLevel;

    public Data() 
    {
        leaves = 0;

        ClickUpgradeLevel = Methods.CreateList<BigDouble>(3);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public string itemName;
    public int itemID;
    public int value;
}

[System.Serializable]
public class ItemDatabase
{
    public List<Item> items = new List<Item>();
}

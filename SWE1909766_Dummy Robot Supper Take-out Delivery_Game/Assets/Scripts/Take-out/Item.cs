using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    private int id;
    [SerializeField] private string itemName;

    public void setID(int menuID)
    {
        id = menuID;
    }

    public void setItem(string item)
    {
        itemName = item;
    }

    public int getID()
    {
        return id;
    }

    public string getItem()
    {
        return itemName;
    }
}

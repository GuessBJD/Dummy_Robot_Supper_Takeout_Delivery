using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bag
{
    [SerializeField] List<Item> bagLog = new List<Item>();

    public void addItem(Item food)
    {
        bagLog.Add(food);
    }

    public List<Item> getAllItems()
    {        
        return bagLog;
    }

    public void reset()
    {
        bagLog.Clear();
    }
}

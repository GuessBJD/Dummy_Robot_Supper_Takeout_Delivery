using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    private const int SIZE = 5;
    [SerializeField] private Bag bag;
    [SerializeField] private Text bagSystemLog;

    private int i;
    private int j;

    public void Awake()
    {
        bagSystemLog.text = "";
        i = 0;
        j = 0;
    }

    public void grab(Item food)
    {
        if(i < SIZE)
        {
            int n = 0;

            bag.addItem(food);

            if(j > 3)
            {
                logReset();
                j = 0;
            }

            bagSystemLog.text += "$[SYSTEM].Bag ";
            foreach (Item itemList in bag.getAllItems())
            {                
                bagSystemLog.text += (n + 1) + ". " + itemList.getItem() + " ";

                n++;
            }
            bagSystemLog.text += "\n";

            i++;
            j++;
        }
        else
        {
            bagSystemLog.text += "$[SYSTEM].Bag Bag FULL \n";
        }
    }

    public void dropAll()
    {
        bag.reset();
        bagSystemLog.text = "";
        i = 0;
        j = 0;
    }

    public List<Item> getBagItems()
    {
        return bag.getAllItems();
    }

    public void logReset()
    {
        bagSystemLog.text = "";
    }
}

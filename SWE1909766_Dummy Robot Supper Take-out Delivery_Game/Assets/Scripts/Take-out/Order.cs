using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Order
{
	[SerializeField] private Menu menu;
	[SerializeField] private string name;
	[SerializeField] private List<Item> items;
	[SerializeField] private GameObject map;

	[SerializeField] private int n = 0;

	public string getName()
    {
		return name;
    }

	public List<Item> getItems()
    {
		return items;
    }

	public string getItemsList()
    {
		string temp = "";
		for(int i = 0; i < n; i++)
        {
			temp = temp + (i + 1) + ". " + items[i].getItem() + "\n";
        }
		return temp;
    }

	public GameObject getMap()
    {
		return map;
    }

	
	public void generateOrder()
    {
		items = menu.randomItems(n);
	}

	/*public int getItemsSize()
    {
		return n;
    }*/
}

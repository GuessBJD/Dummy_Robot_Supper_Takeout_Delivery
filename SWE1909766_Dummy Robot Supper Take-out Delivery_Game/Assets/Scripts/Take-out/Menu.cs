using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] public FoodRegister[] menu;

    private int id;

    void Awake()
    {
        foreach (FoodRegister reg in menu)
        {
            reg.getItemEntry().setID(id);
            id++;
        }
    }

    public List<Item> randomItems(int size)
    {
        int n = 0;

        List<Item> itemsList = new List<Item>();

        for (int i = 0; i < size; i++)
        {
            n = (Random.Range(0, id)) % id;

            itemsList.Add(menu[n].getItemEntry());
        }

        return itemsList;
    }
}

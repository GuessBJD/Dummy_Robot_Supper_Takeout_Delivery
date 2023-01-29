using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodRegister : MonoBehaviour
{
    [SerializeField] private Item itemEntry;

    public Item getItemEntry()
    {
        return itemEntry;
    }
}

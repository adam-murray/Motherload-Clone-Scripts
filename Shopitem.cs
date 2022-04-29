using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    public enum ItemType
    {
        FuelNone,
        Fuel_1,
        Fuel_2,
    }

    public static int GetCost(ItemType itemType)
    {
        switch (itemType)
        {
            default:
            case ItemType.FuelNone: return 0;
            case ItemType.Fuel_1:   return 100;
            case ItemType.Fuel_2:   return 300;
        }
    }
}

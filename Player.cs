using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IShopCustomer
{
    public void BoughtItem(ShopItem.ItemType itemType)
    {
        Debug.Log("Bought item");
    }
}

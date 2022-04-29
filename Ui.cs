using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Ui : MonoBehaviour
{
    public Transform container;
    public Transform shopItem;
    private Text shopItemName;
    private Text shopItemPrice;
    private IShopCustomer shopCustomer;
    private Button button;
    //private transform containerItem;
    private void Awake()
    {
        //shopItem.gameObject.SetActive(false);
    }
    private void Start()
    {
        CreateItemButton(ShopItem.ItemType.Fuel_1, "Fuel 1", 5, 0);
        CreateItemButton(ShopItem.ItemType.Fuel_2, "Fuel 2", 10, 1);
    }
    private void CreateItemButton(ShopItem.ItemType itemType, string itemName, int itemCost, int positionIndex)
    {
        Transform shopItemTransform = Instantiate(shopItem, container);
        RectTransform shopItemRectTransform = shopItemTransform.GetComponent<RectTransform>();

        float shopItemHeight = 100f;

        shopItemRectTransform.anchoredPosition = new Vector2(0, -shopItemHeight * positionIndex);
        shopItemTransform.Find("shopItemName").GetComponent<Text>().text = itemName;

        shopItemPrice = shopItemTransform.Find("shopItemPrice").GetComponent<Text>();
        shopItemPrice.text = itemCost.ToString();
        Debug.Log(container.parent.gameObject);
        button = shopItemTransform.GetComponent<Button>();

        button.onClick.AddListener(delegate { TryBuyItem(itemType); });
    }
    private void TryBuyItem(ShopItem.ItemType itemType)
    {
        shopCustomer.BoughtItem(itemType);
    }
}

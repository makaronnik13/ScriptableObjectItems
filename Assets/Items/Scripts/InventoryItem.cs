using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Item inventoryItem
    {
        get
        {
            return GetComponentInChildren<ItemVisual>().Item;
        }
    }


    public void Init(Item item)
    {
        GetComponentInChildren<ItemVisual>().Init(item);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<Inventory>().ShowItemInfo(inventoryItem);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<Inventory>().ShowItemInfo(null);
    }
}

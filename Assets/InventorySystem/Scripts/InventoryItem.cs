using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Контроллер предмета в инвентаре

public class InventoryItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //ScriptableObject предмета
    private Item inventoryItem
    {
        get
        {
            return GetComponentInChildren<ItemVisual>().Item;
        }
    }

    //Инициализация ScriptableObject-ом предмета, вызывает инициализацию на визуальном представлении
    public void Init(Item item)
    {
        GetComponentInChildren<ItemVisual>().Init(item);
    }

    //При наведении курсора, вызывает показ информации на Inventory
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponentInParent<Inventory>().ShowItemInfo(inventoryItem);
    }

    //При убирании курсора, вызывает показ информации о нулевом объекте на Inventory (прячет информацию)
    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponentInParent<Inventory>().ShowItemInfo(null);
    }
}

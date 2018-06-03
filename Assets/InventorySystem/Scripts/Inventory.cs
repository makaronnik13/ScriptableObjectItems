using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
Скрипт, отвечающий за отображение инвентаря
 */

public class Inventory : MonoBehaviour {

    //ссылка на персонажа
    public PlayerIdentity player;

    //Transform объекта, куда помещаются все визуальные представления предметов инвентаря 
    public Transform slots;

    //префаб предмета в инвентаре
    public GameObject ItemVisual;

    //текст названия предмета и описания
    public Text ItemName;
    public Text ItemDescription;

    //Вызывается кнопкой инвентаря и показывает/скрывает окно инвентаря
	public void InventoryClicked()
    {
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
    }

    private void Start()
    {
        //подписываемся на события получения/потери предметов
        player.OnItemRecieved += ItemRecieved;
        player.OnItemLost += ItemLost;
    }


    //Вызывается при наведении курсора на предмет, показывает информацию о нем
    public void ShowItemInfo(Item item)
    {
        ItemName.enabled = item != null;
        ItemDescription.enabled = item != null;
        if (item)
        {
            ItemName.text = item.ItemName;
            ItemDescription.text = item.ItemDescription;
        }
    }

    //Вызывается при получении предмета и создаёт его визуальное представление в инвентаре
    private void ItemRecieved(Item item)
    {
        Transform freeSlot = GetFreeSlot();
        GameObject itemVisual = Instantiate(ItemVisual, freeSlot.transform.position, Quaternion.identity, freeSlot);
        itemVisual.GetComponent<InventoryItem>().Init(item);
    }

    //Вызывается при потери предмета
    private void ItemLost(Item item)
    {
       
    }

    //Ищет первый свободный слот в окне инвентаря
    private Transform GetFreeSlot()
    {
        foreach (Transform t in slots)
        {
            if (t.childCount == 0)
            {
                return t;
            }
        }

        return null;
    }

  
}

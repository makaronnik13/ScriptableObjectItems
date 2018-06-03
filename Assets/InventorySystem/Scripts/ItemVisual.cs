using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Визуальное представление предмета, не делает ничего, кроме изменения картинки при инициализации,
//Работает для Image и для SpriteRenderer, чтобы использовать и для предметов в инвентаре и для предметов вне его

public class ItemVisual : MonoBehaviour
{
    private Item visualisingItem;
    public Item Item
    {
        get
        {
            return visualisingItem;
        }
    }

    public void Init(Item item)
    {
        visualisingItem = item;
        if (GetComponent<SpriteRenderer>())
        {
            GetComponent<SpriteRenderer>().sprite = item.ItemImg;
        }

        if (GetComponent<Image>())
        {
            GetComponent<Image>().sprite = item.ItemImg;
        }
    }
}

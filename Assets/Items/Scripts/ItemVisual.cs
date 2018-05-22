using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

    public PlayerIdentity player;
    public Transform slots;
    public GameObject ItemVisual;
    public Text ItemName;
    public Text ItemDescription;

	public void InventoryClicked()
    {
        transform.GetChild(0).gameObject.SetActive(!transform.GetChild(0).gameObject.activeInHierarchy);
    }

    private void Start()
    {
        player.OnItemRecieved += ItemRecieved;
        player.OnItemLost += ItemLost;
    }

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

    private void ItemLost(Item item)
    {
       
    }

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

    private void ItemRecieved(Item item)
    {
        Transform freeSlot = GetFreeSlot();
        GameObject itemVisual = Instantiate(ItemVisual, freeSlot.transform.position, Quaternion.identity, freeSlot);
        itemVisual.GetComponent<InventoryItem>().Init(item);
    }
}

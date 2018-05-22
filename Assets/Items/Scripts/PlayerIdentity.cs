using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdentity : MonoBehaviour {

    private IActivatable focusedActivatable;

    public Action<Item> OnItemRecieved = (item)=> { };
    public Action<Item> OnItemLost = (item) => { };

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (focusedActivatable!=null)
            {
                focusedActivatable.Activate();
            }
        }
    }

    public void TakeItem(Item item)
    {
        OnItemRecieved.Invoke(item);
    }

    public void DropItem(Item item)
    {
        OnItemLost.Invoke(item);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        IActivatable iA = collider.GetComponentInChildren<IActivatable>();
        if (collider.GetComponent<IActivatable>()!=null)
        {
            iA = collider.GetComponent<IActivatable>();
        }

        if (iA!=null)
        {
            focusedActivatable = iA;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        focusedActivatable = null;
    }
}

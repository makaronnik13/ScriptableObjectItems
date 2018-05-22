using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItem : MonoBehaviour {

    private Item worldItem
    {
        get
        {
            return GetComponentInChildren<ItemVisual>().Item;
        }
    }

	public void Init(Item item)
    {
        GetComponentInChildren<ItemVisual>().Init(item);
        StartCoroutine(EnableCollider());
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerIdentity>())
        {   
                collider.GetComponent<PlayerIdentity>().TakeItem(worldItem);
                Destroy(transform.parent.gameObject);
        }
    }
}

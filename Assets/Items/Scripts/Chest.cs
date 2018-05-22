using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest :MonoBehaviour, IActivatable
{
    public float DropForce = 1;
    public Item[] items;
    public GameObject ItemPrefab;

    public void Activate()
    {
        GetComponent<Animator>().SetTrigger("Opened");
        foreach (Item item in items)
        {
            GameObject worldItem = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
            worldItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-DropForce/2f,DropForce/2f), DropForce));
            worldItem.GetComponentInChildren<WorldItem>().Init(item);
        }
    }
}

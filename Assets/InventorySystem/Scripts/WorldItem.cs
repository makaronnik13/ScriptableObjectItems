using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Контроллер предмета вне инвентаря
public class WorldItem : MonoBehaviour {

    //ScriptableObject предмета
    private Item worldItem
    {
        get
        {
            return GetComponentInChildren<ItemVisual>().Item;
        }
    }

    //Инициализация ScriptableObject-ом
	public void Init(Item item)
    {
        GetComponentInChildren<ItemVisual>().Init(item);
        StartCoroutine(EnableCollider());
    }

    //Включаем коллайдер предмета через секунду, чтобы он не подбирался сразу, как только вылетает из сундука
    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(1);
        GetComponent<Collider2D>().enabled = true;
    }

    //Подбираем предмет, если в него вошел игрок
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.GetComponent<PlayerIdentity>())
        {   
                collider.GetComponent<PlayerIdentity>().TakeItem(worldItem);
                Destroy(transform.parent.gameObject);
        }
    }
}

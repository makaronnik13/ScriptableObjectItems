using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Скрипт игрока, позволяющий активировать объекты с интерфейсом  IActivatable и подбирать предметы
public class PlayerIdentity : MonoBehaviour {

    //Активируемый объект, рядом с которым находится игрок
    private IActivatable focusedActivatable;

    //Событие подбора предмета
    public Action<Item> OnItemRecieved = (item)=> { };
    //Событие потери предмета
    public Action<Item> OnItemLost = (item) => { };

    private void Update()
    {
        //Активируем объект, если он есть рядом и мы нажали Fire1
        if (Input.GetButtonDown("Fire1"))
        {
            if (focusedActivatable!=null)
            {
                focusedActivatable.Activate();
            }
        }
    }

    //Подобрать предмет
    public void TakeItem(Item item)
    {
        OnItemRecieved.Invoke(item);
    }

    //Выкинуть предмет
    public void DropItem(Item item)
    {
        OnItemLost.Invoke(item);
    }

    //При входе в тригер ищем на его объекте активируемый объект
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

    //обнуляем ближайший активируемый объект
    private void OnTriggerExit2D(Collider2D collision)
    {
        focusedActivatable = null;
    }
}

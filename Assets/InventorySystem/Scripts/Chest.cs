using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//скрипт сундука
public class Chest :MonoBehaviour, IActivatable
{
    //сила, с которой предметы вылетают из сундука
    public float DropForce = 1;

    //Массив предметов в сундуке
    public Item[] items;

    //Префаб предмета
    public GameObject ItemPrefab;

    //Реализация интерфейса IActivatable
    public void Activate()
    {
        //вызываем анимацию сундука тригером
        GetComponent<Animator>().SetTrigger("Opened");

        //для всех предметов в сундуке создаём их визуальное представление, придаём им скорость (выкидываем из сундука) и инициализируем ScriptableObject-ом
        foreach (Item item in items)
        {
            GameObject worldItem = Instantiate(ItemPrefab, transform.position, Quaternion.identity);
            worldItem.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-DropForce/2f,DropForce/2f), DropForce));
            worldItem.GetComponentInChildren<WorldItem>().Init(item);
        }
    }
}

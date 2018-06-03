using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ScriptableObject предмета
[CreateAssetMenu( menuName ="Item")]
public class Item : ScriptableObject
{
    //Перечисление для типа предмета
    public enum ItemType
    {
        Quest,
        Weapon,
        Clothes,
        Usable,
        Material
    }

    //Перечисление для типа оружия
    public enum WeaponType
    {
        Bow,
        Heavy,
        OneHand,
        Shield,
        Magic
    }

    //Перечисление для типа одежды
    public enum ClothesType
    {
        Boots,
        Hat,
        Jacket,
        Pants,
        Artefact
    }

    //тип предмета
    public ItemType ItemItemType;
    //тип оружия
    public WeaponType ItemWeaponType;
    //тип одежды
    public ClothesType ItemClothesType;

    //картинка предмета
    public Sprite ItemImg;
    //название предмета
    public string ItemName;
    //описание предмета
    public string ItemDescription;
    //количество зарядов
    public int Charges;
}

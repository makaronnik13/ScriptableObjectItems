using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName ="Item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {
        Quest,
        Weapon,
        Clothes,
        Usable,
        Material
    }

    public enum WeaponType
    {
        Bow,
        Heavy,
        OneHand,
        Shield,
        Magic
    }

    public enum ClothesType
    {
        Boots,
        Hat,
        Jacket,
        Pants,
        Artefact
    }

    public ItemType ItemItemType;
    public WeaponType ItemWeaponType;
    public ClothesType ItemClothesType;

    public Sprite ItemImg;
    public string ItemName;
    public string ItemDescription;

    public int Charges;
}

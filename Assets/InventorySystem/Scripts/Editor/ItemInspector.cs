using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

//Кастомный инспектор для предмета
[CustomEditor(typeof(Item))]
public class ItemInspector : Editor
{
    //редактируемый предмет
    private Item item;

    private void OnEnable()
    {
        item = (Item)target;
    }

    //Метод отрисовки инспектора
    public override void OnInspectorGUI()
    {
        //название, описание и картинка предмета
        item.ItemName = EditorGUILayout.TextField("Name", item.ItemName);
        item.ItemDescription = EditorGUILayout.TextField("Description", item.ItemDescription);
        item.ItemImg = (Sprite)EditorGUILayout.ObjectField("Sprite", item.ItemImg, typeof(Sprite), false);

        //дропдаун для типа предмета
        item.ItemItemType = (Item.ItemType)EditorGUILayout.EnumPopup("Item type",item.ItemItemType);

        //если тип предмета - одежда, рисуем дропдаун для типа одежды
        if (item.ItemItemType == Item.ItemType.Clothes)
        {
            item.ItemClothesType = (Item.ClothesType)EditorGUILayout.EnumPopup("Clothes type", item.ItemClothesType);
        }

        //если тип предмета - оружие, рисуем дропдаун для типа оружия
        if (item.ItemItemType == Item.ItemType.Weapon)
        {
            item.ItemWeaponType = (Item.WeaponType)EditorGUILayout.EnumPopup("Weapon type", item.ItemWeaponType);
        }

        //если тип предмета - используемый, рисуем поле для количества зарядов
        if (item.ItemItemType == Item.ItemType.Usable)
        {
            item.Charges = EditorGUILayout.IntField("Charges", item.Charges);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Item))]
public class ItemInspector : Editor
{

    private Item item;

    private void OnEnable()
    {
        item = (Item)target;
    }

    public override void OnInspectorGUI()
    {
        item.ItemName = EditorGUILayout.TextField("Name", item.ItemName);
        item.ItemDescription = EditorGUILayout.TextField("Description", item.ItemDescription);
        item.ItemImg = (Sprite)EditorGUILayout.ObjectField("Sprite", item.ItemImg, typeof(Sprite), false);

        item.ItemItemType = (Item.ItemType)EditorGUILayout.EnumPopup("Item type",item.ItemItemType);

        if (item.ItemItemType == Item.ItemType.Clothes)
        {
            item.ItemClothesType = (Item.ClothesType)EditorGUILayout.EnumPopup("Clothes type", item.ItemClothesType);
        }

        if (item.ItemItemType == Item.ItemType.Weapon)
        {
            item.ItemWeaponType = (Item.WeaponType)EditorGUILayout.EnumPopup("Weapon type", item.ItemWeaponType);
        }

        if (item.ItemItemType == Item.ItemType.Usable)
        {
            item.Charges = EditorGUILayout.IntField("Charges", item.Charges);
        }
    }
}

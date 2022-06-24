using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 완제품 클래스
[System.Serializable]
public class CraftedItemClass : ItemClass
{
    public List<int> matItemList;
    Sprite sprite;

    public CraftedItemClass()
    {
        name = "craftedItem";
        num = 0;
        tooltip = "test craft tooltip";
        dialog = "test craft dialog";
        matItemList = new List<int>();
    }

    public Sprite loadImg()
    {
        if (sprite == null)
        {
            sprite = Resources.Load<Sprite>("Hyunsu/Item/" + name);
        }
        return sprite;
    }
}
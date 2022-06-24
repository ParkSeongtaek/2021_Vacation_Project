using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 완제품 래퍼
[System.Serializable]
public class CraftedItemWrapper
{
    public List<CraftedItemClass> craftedItemList;

    public CraftedItemWrapper()
    {
        craftedItemList = new List<CraftedItemClass>();
        craftedItemList.Add(new CraftedItemClass());
    }
}

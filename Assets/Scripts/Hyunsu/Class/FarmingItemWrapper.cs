using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 래퍼
[System.Serializable]
public class FarmingItemWrapper
{
    public List<FarmingItemClass> farmingItemList;

    public FarmingItemWrapper()
    {
        farmingItemList = new List<FarmingItemClass>();
        farmingItemList.Add(new FarmingItemClass());
    }
}
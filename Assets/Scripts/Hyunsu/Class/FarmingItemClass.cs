using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class FarmingItemClass : ItemClass
{
    public Vector2 itemVec;

    // 스프라이트 인식기
    [System.NonSerialized]
    public GameObject aimObj;

    public FarmingItemClass()
    {
        name = "farmingItem";
        num = 0;
        tooltip = "test farming tooltip";
        dialog = "test farming dialog";
        itemVec = new Vector2(0, 0);
    }
}
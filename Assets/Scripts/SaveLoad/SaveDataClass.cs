using System.Collections;
using System.Collections.Generic;
using UnityEngine;



// 세이브 데이터 클래스
[System.Serializable]
public class SaveDataClass
{
    public List<int> ownedItemList;
    public List<int> usedItemList;
    public string nextNovel;
    public SceneName nowScene;
    public SaveDataClass()
    {
        nowScene = SceneName.NovelScene;
        ownedItemList = new List<int>();
        usedItemList = new List<int>();
        nextNovel = "찐 prologue1";

    }
    public bool FindOwnedItem(int itemidx)
    {
        bool have = false;
        Debug.Log("ownedItemList을 찾아보자");

        for (int i = 0; i < ownedItemList.Count && !have; i++)
        {
            Debug.Log("ownedItemList" + i + "=" + ownedItemList[i]);
            if (ownedItemList[i] == itemidx)
                have = true;
        }
        return have;
    }

}
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
        nextNovel = "prologue1";
    }
}
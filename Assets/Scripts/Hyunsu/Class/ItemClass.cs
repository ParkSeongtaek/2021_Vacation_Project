using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 아이템 클래스
[System.Serializable]
public class ItemClass
{
    public string name;
    public int num;
    public string tooltip;
    public string dialog;
    public string NextNovel;


    public ItemClass()
    {
        name = "initName";
        num = 0;
        tooltip = "test tooltip";
        dialog = "test dialog";
        NextNovel = "test farming NextNovel";
    }
}
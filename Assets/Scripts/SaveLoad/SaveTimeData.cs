using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//언제 세이브 되었는지에 대한 enum값.
public enum SaveTime
{
    NotStarted,프롤로그, 제1장, 제2장, 제3장
}

[System.Serializable]
public class SaveTimeData
{
    //어느 시점에서 세이브 되었는지
    public SaveTime saveTime;
    //몇시 몇분에 세이브 되었는지.
    public string dateTimeString;

    public SaveTimeData()
    {
        saveTime = SaveTime.NotStarted;
        dateTimeString = null;
    }
}

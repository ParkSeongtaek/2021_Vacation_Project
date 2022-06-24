using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



[System.Serializable]
public class SaveTimeDataWrapper
{
    public SaveTimeData[] saveTimeDataArray;


    public SaveTimeDataWrapper()
    {
        saveTimeDataArray = new SaveTimeData[4];
        for(int i = 0; i < saveTimeDataArray.Length; i++)
        {
            saveTimeDataArray[i] = new SaveTimeData();
        }
    }

    public void ChangeDateTimeToNow(int index)
    {
        saveTimeDataArray[index].dateTimeString = DateTime.Now.ToShortDateString();
    }
}

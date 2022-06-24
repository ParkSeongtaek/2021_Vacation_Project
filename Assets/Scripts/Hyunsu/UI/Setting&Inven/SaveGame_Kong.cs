using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
public class SaveGame_Kong : MonoBehaviour
{
    SaveLoadMgr saveloadmgr;
    [SerializeField] GameObject saveWindow;
    public Text[] loadTextArray;
    SaveTimeDataWrapper saveDataTimeWrapper;
    public void Start()
    {
        saveloadmgr = SaveLoadMgr.instance;
        saveDataTimeWrapper = SaveLoadMgr.instance.saveTimeDataWrapper;

        for(int i = 0; i < saveDataTimeWrapper.saveTimeDataArray.Length; i++)
        {
            SaveTimeData data = saveDataTimeWrapper.saveTimeDataArray[i];
            if(data.saveTime == SaveTime.NotStarted)
            {
                loadTextArray[i].text = "비어있음";
                continue;
            }
            StringBuilder builder = new StringBuilder(data.saveTime.ToString());
            builder.Append("\n\n");
            builder.Append(data.dateTimeString);
            loadTextArray[i].text = builder.ToString();
        }
    }
    public void SaveButton(int index)
    {
        saveloadmgr.SaveCurrentData(index);
    }
    public void OnClickSaveGame()
    {
        saveWindow.SetActive(true);
    }
    public void OnClickSaveClose()
    {
        saveWindow.SetActive(false);
    }
}

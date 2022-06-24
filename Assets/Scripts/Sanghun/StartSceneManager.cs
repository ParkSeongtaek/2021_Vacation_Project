using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class StartSceneManager : MonoBehaviour
{
    //어디에 저장되어있는지 표시 
    [SerializeField] GameObject loadWindow;
    public Text[] loadTextArray;
    SaveTimeDataWrapper saveDataTimeWrapper;
    void Start()
    {
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

    public void LoadButton(int index)
    {
        SaveLoadMgr.instance.LoadSaveData(index);
    }
    // 몇번쨰 게임을 로딩할지 정하는 창을 띄워줌
    public void OnClickLoadGame()
    {
        loadWindow.SetActive(true);
    }

    // 바로 위에 뜬 창을 닫는 버튼
    public void OnClickLoadClose()
    {
        loadWindow.SetActive(false);
    }
}

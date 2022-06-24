using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnMgr : MonoBehaviour
{
    [SerializeField] GameObject setting;
    [SerializeField] CraftingMgr craftMgr;

    // 설정창 열기
    public void OnClickSettingBtn()
    {
        setting.SetActive(true);
    }

    // 설정창 닫기
    public void OnClickSettingCloseBtn()
    {
        setting.SetActive(false);
    }
    
    // 세이브 버튼
    public void OnClickSaveBtn(int index)
    {
        SaveLoadMgr.instance.SaveCurrentData(index);
    }

    public void makeBtn()
    {
        craftMgr.ItemCrafting(craftMgr.ItemOnCraftList);
    }

    public void LoadNovelScene()
    {
        //SceneMoveMgr.instance.LoadScene(SceneName.NovelScene);
        SceneMoveMgr.instance.LoadScene(SceneName.TestScene);
    }
}
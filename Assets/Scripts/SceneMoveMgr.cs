using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum SceneName
{
    StartScene,NovelScene, FarmingScene, MiniGame1Scene, MiniGame2Scene, MiniGame3Scene, TestScene
}

// 신 이동할때 쓰는 스크립트
public class SceneMoveMgr : MonoBehaviour
{
    public static SceneMoveMgr instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
   
    public int nextindex;
    public string nextnovel;
    // 파밍 모드로 들어가게 해주는 버튼
    public void OnClickFarmingBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void LoadScene(int index)
    {
        SaveLoadMgr.instance.saveData.nowScene = (SceneName)index;
        SaveLoadMgr.instance.AutoSaveData();
        SceneManager.LoadScene(index);
    }

    public void LoadScene(SceneName scene)
    {
        SaveLoadMgr.instance.saveData.nowScene = scene;
        SaveLoadMgr.instance.AutoSaveData();
        SceneManager.LoadScene((int)scene);
    }
}

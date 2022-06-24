using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadMgr : MonoBehaviour
{
    [SerializeField] GameObject loadWindow; //  load game 창
    [SerializeField] SceneMoveMgr sceneMover;   //  신 옮겨주는 거
    public SaveDataClass saveData;
    //StartSceneManager에서 갖다씀
    [HideInInspector]
    public SaveTimeDataWrapper saveTimeDataWrapper;
    JsonMgr jsonMgr;
    public static SaveLoadMgr instance;

    
    private void Awake()
    {
        // 신이 옮겨져도 파괴되지 않게 해주는거
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

    void Start()
    {
        jsonMgr = new JsonMgr();
        //시작할 때 전체 시간 진행도를 받아오고 그걸 제이슨으로 가져옴.
        saveTimeDataWrapper = jsonMgr.LoadSaveTimeData();
        JsonMgr.saveTimeDataWrapper = saveTimeDataWrapper;
        sceneMover = SceneMoveMgr.instance;
        //saveData = new SaveDataClass();
        //Debug.Log("생성자 실행");
        ////비어있는 0번 데이터 저장
        //jsonMgr.SaveJson(saveData, 0);

        // json 파일 생성을 위한 코드
        //CraftedItemWrapper cratedItemWrapper = new CraftedItemWrapper();
        //jsonMgr.SaveJson<CraftedItemWrapper>(cratedItemWrapper, "CraftedItemDataList");

        //FarmingItemWrapper itemListWrapper = new FarmingItemWrapper();
        //jsonMgr.SaveJson<FarmingItemWrapper>(itemListWrapper, "FarmingItemDataList");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // 세이브된 데이터를 불러오기
    public void LoadSaveData(int index)
    {
        Debug.Log("로드 인덱스" + index);
        saveData = jsonMgr.LoadSaveData(index);
        // 해당 인덱스에 저장된 데이터가 없을떄
        if (saveData == null)
        {
            
            //없으면 새로 만들어준다.
            saveData = new SaveDataClass();
            jsonMgr.SaveJson(saveData, index);
        }
        //else
        //{
        //    // 있으면 해당 데이터를 불러온다
        //    sceneMover.OnClickFarmingBtn(); // 이건 임시로 해둔건데 파밍 모드로 바로 들어가게 해놨음
        //}
        Debug.Log(saveData.nowScene);
        sceneMover.LoadScene(saveData.nowScene);
        saveTimeDataWrapper.ChangeDateTimeToNow(index);


    }
    // 현재 데이터를 저장
    public void SaveCurrentData(int index)
    {
        if (saveData.nextNovel.Contains("prologue"))
        {
            saveTimeDataWrapper.saveTimeDataArray[index].saveTime = SaveTime.프롤로그;
        }
        else if (saveData.nextNovel.Contains("first"))
        {
            saveTimeDataWrapper.saveTimeDataArray[index].saveTime = SaveTime.제1장;
        }
        else if (saveData.nextNovel.Contains("second"))
        {
            saveTimeDataWrapper.saveTimeDataArray[index].saveTime = SaveTime.제2장;
        }
        else if (saveData.nextNovel.Contains("third"))
        {
            saveTimeDataWrapper.saveTimeDataArray[index].saveTime = SaveTime.제3장;
        }
        jsonMgr.SaveJson<SaveTimeDataWrapper>(saveTimeDataWrapper, "SaveTimeDataWrapper");   
        jsonMgr.SaveJson(saveData, index);
    }

    //상훈이가 만든 코드
    public void AutoSaveData()
    {
        SaveCurrentData(0);
    }

    // 새로운 게임 시작하는 버튼
    public void OnClickNewGame()
    {
        // 아무것도 저장되어 있지 않는 0번 데이터를 불러옴
        saveData = new SaveDataClass();
        AutoSaveData();

        //sceneMover.OnClickFarmingBtn(); // 얘도 일단 파밍모드로 들어가게 해둔거임
        //주석 누가써놨어 잘써놨네~
        sceneMover.LoadScene(SceneName.NovelScene);
    }

}
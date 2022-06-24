using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class JsonMgr
{
    public static SaveTimeDataWrapper saveTimeDataWrapper;
    // 세이브데이터를 세이브해줌
    public void SaveJson(SaveDataClass saveData, int index)
    {
        saveTimeDataWrapper.saveTimeDataArray[index].dateTimeString = System.DateTime.Now.ToString();
        string jsonText;

        // 안드로이드에서의 저장 위치를 다르게 해줘야 한다
        // 안드로이드의 경우 데이터 조작을 막기 위해 2진 데이터로 변환해야 한다

        string savePath = Application.dataPath;
        string appender = "/userData/";
        string nameString = "SaveData";
        string dotJson = ".json";

#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDRIOD

#endif
        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        if (!Directory.Exists(builder.ToString()))
        {
            // 디렉토리가 없는 경우 만들어준다
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(nameString);
        builder.Append(index.ToString());
        builder.Append(dotJson);

        jsonText = JsonUtility.ToJson(saveData, true);
        //데이터를 텍스트로 변환
        //jsonUtility를 이용하여 data를 json 형식의 text로 바꿔준다

        //파일 스트림을 지정해주고 저장한다
        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();

        //여기서부터는 세이브타임데이터 불러오기
//        nameString = "SaveTimeDataWrapper";

//#if UNITY_EDITOR_WIN

//#endif
//#if UNITY_ANDRIOD

//#endif
//        builder.Clear();
//        builder = new StringBuilder(savePath);
//        builder.Append(appender);
//        if (!Directory.Exists(builder.ToString()))
//        {
//            // 디렉토리가 없는 경우 만들어준다
//            Directory.CreateDirectory(builder.ToString());
//        }
//        builder.Append(nameString);
//        builder.Append(dotJson);

//        jsonText = JsonUtility.ToJson(saveData, true);
//        //데이터를 텍스트로 변환
//        //jsonUtility를 이용하여 data를 json 형식의 text로 바꿔준다

//        //파일 스트림을 지정해주고 저장한다
//        fileStream = new FileStream(builder.ToString(), FileMode.Create);
//        bytes = Encoding.UTF8.GetBytes(jsonText);
//        fileStream.Write(bytes, 0, bytes.Length);
//        fileStream.Close();
    }
    // 리소스 데이터를 불러오기
    public T ResourceDataLoad<T>(string name)
    {
        // 이전에 저장했던 데이터를 꺼낸다
        // 만일 저장한 데이터가 없다면 이걸 실행하지 않고 새 게임을 실행한다. 그 작업은 신로더에서 해준다
        T gameData;

        string directory = "JsonData/";
        string appender1 = name;
        StringBuilder builder = new StringBuilder(directory);
        builder.Append(appender1);
        //위 까지는 세이브랑 같다z
        //파일 스트림을 만들어준다. 파일 모드를 open으로 열어준다
        TextAsset jsonString = Resources.Load<TextAsset>(builder.ToString());
        gameData = JsonUtility.FromJson<T>(jsonString.ToString());

        return gameData;
        // 이 정보를 게임매니저나 로딩으로 넘겨준다
    }
    // 세이브 데이터를 불러오기
    public SaveDataClass LoadSaveData(int index)
    {
        saveTimeDataWrapper.saveTimeDataArray[index].dateTimeString = System.DateTime.Now.ToString();
        SaveDataClass gameData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/SaveData";

        string dotJson = ".json";

#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID

#endif

        StringBuilder builder = new StringBuilder(loadPath);
        builder.Append(directory);

        string builderToString = builder.ToString();
        if (!Directory.Exists(builderToString))
        {
            // 디렉토리가 없는 경우 만들어준다
            Directory.CreateDirectory(builderToString);
        }
        builder.Append(appender);
        builder.Append(index.ToString());
        builder.Append(dotJson);

        if (File.Exists(builder.ToString()))
        {
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);

            // 텍스트를 string으로 바꾼다음 FromJson에 넣어주면 우리가 쓸수 있는 객체로 바꿀수 있다
            gameData = JsonUtility.FromJson<SaveDataClass>(jsonData);
        }
        else
        {
            // 세이브 파일이 없는 경우
            //gameData = new SaveDataClass();

            return null;
        }
        return gameData;
        // 이 정보를 게임매니저나 로딩으로 넘겨준다
    }

    public SaveTimeDataWrapper LoadSaveTimeData()
    {
        SaveTimeDataWrapper gameData;
        string loadPath = Application.dataPath;
        string directory = "/userData";
        string appender = "/SaveTimeDataWrapper";

        string dotJson = ".json";

#if UNITY_EDITOR_WIN

#endif

#if UNITY_ANDROID

#endif

        StringBuilder builder = new StringBuilder(loadPath);
        builder.Append(directory);

        string builderToString = builder.ToString();
        if (!Directory.Exists(builderToString))
        {
            // 디렉토리가 없는 경우 만들어준다
            Directory.CreateDirectory(builderToString);
        }
        builder.Append(appender);
        builder.Append(dotJson);

        if (File.Exists(builder.ToString()))
        {
            FileStream stream = new FileStream(builder.ToString(), FileMode.Open);

            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            stream.Close();
            string jsonData = Encoding.UTF8.GetString(bytes);
            Debug.Log(jsonData);
            // 텍스트를 string으로 바꾼다음 FromJson에 넣어주면 우리가 쓸수 있는 객체로 바꿀수 있다
            gameData = JsonUtility.FromJson<SaveTimeDataWrapper>(jsonData);
        }
        else
        {
            // 세이브 파일이 없는 경우
            //gameData = new SaveDataClass();

            gameData = new SaveTimeDataWrapper();
        }
        return gameData;
        // 이 정보를 게임매니저나 로딩으로 넘겨준다
    }

    // 제이슨 파일로 저장
    public void SaveJson<T>(T saveData, string name)
    {
        string jsonText;

        string savePath = Application.dataPath;
        string appender = "/userData/";
        string nameString = name + ".json";

#if UNITY_EDITOR_WIN

#endif
#if UNITY_ANDROID

#endif
        StringBuilder builder = new StringBuilder(savePath);
        builder.Append(appender);
        if (!Directory.Exists(builder.ToString()))
        {
            Directory.CreateDirectory(builder.ToString());
        }
        builder.Append(nameString);

        jsonText = JsonUtility.ToJson(saveData, true);

        FileStream fileStream = new FileStream(builder.ToString(), FileMode.Create);
        byte[] bytes = Encoding.UTF8.GetBytes(jsonText);
        fileStream.Write(bytes, 0, bytes.Length);
        fileStream.Close();
    }

}

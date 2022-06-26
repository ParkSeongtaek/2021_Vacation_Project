using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class TextManager : MonoBehaviour
{
    Dictionary<int, Sprite> imgdata; //인물 이미지 저장
    Dictionary<int, Sprite> bgdata; //배경화면 저장
    public Sprite[] characterImg;
    public Sprite[] backgroundimg;
    public SaveDataClass saveData;
    string[] line;
    string eraseCR;
    TextAsset txt; //대화 파일 가져옴
    
    void Start()
    {
        imgdata = new Dictionary<int, Sprite>(); //초기화
        bgdata = new Dictionary<int, Sprite>(); //초기화
        GenerateData();
        saveData = SaveLoadMgr.instance.saveData;

        StringBuilder builder = new StringBuilder("Miju/");
        builder.Append(saveData.nextNovel);
        Debug.Log(builder.ToString());
        txt = Resources.Load<TextAsset>(builder.ToString());

        if ((int)eraseCR[eraseCR.Length - 1] == 13)
        {
            eraseCR.Remove(eraseCR.Length - 1);
        }

        Debug.Log(txt.text);
        for (int i = 0; i < builder.ToString().Length; i++)
        {
            Debug.Log(builder.ToString()[i]);
            Debug.Log((int)builder.ToString()[i]);
        }


    }

    void GenerateData() //이미지 데이터 저장
    {
        
        imgdata.Add(8, characterImg[0]); //손님
        imgdata.Add(50, characterImg[1]); //주모
        imgdata.Add(60, characterImg[2]); //호위무사
        imgdata.Add(40, characterImg[3]); //김씨 아저씨
        imgdata.Add(30, characterImg[4]); //???, 김옥혜
        imgdata.Add(10, characterImg[5]); //성준영
        imgdata.Add(20, characterImg[6]); ///???, 이순
        imgdata.Add(70, characterImg[7]); //사또
        imgdata.Add(80, characterImg[8]); //어머니
        imgdata.Add(3, characterImg[9]); //노인(마을사람1)
        imgdata.Add(90, characterImg[10]); //앞집 아주머니


        bgdata.Add(1, backgroundimg[4]); //집
        bgdata.Add(4, backgroundimg[5]); //저잣거리
        bgdata.Add(5, backgroundimg[2]); //주막
        bgdata.Add(15, backgroundimg[7]); //관청 낮
        bgdata.Add(22, backgroundimg[1]); //하늘
        bgdata.Add(23, backgroundimg[3]);//관청-개기일식
        bgdata.Add(24, backgroundimg[6]); //주막-개기일식
        bgdata.Add(25, backgroundimg[8]); //준영 집 내부
        bgdata.Add(26, backgroundimg[9]); //부엌
        bgdata.Add(27, backgroundimg[10]); //준영집 마당
        bgdata.Add(28, backgroundimg[11]); //산중턱
        bgdata.Add(29, backgroundimg[12]); //산입구in
        bgdata.Add(30, backgroundimg[13]); //산입구out

        bgdata.Add(100, backgroundimg[0]); //검정배경



    }
    public string Splittxt(int index) 
    {
        string currentText = txt.text.Substring(0, txt.text.Length); // txt 파일을 가져와 첫번째 줄부터 마지막-1줄까지 가져옴(마지막 줄이 내용없이 줄바꿈임)
        //이거 -1할 필요없어요. 뺐습니다 -상훈-
        line = currentText.Split('\n'); //줄바꿈을 기준으로 잘라서 배열에 저장
        Debug.Log(line.Length);
        return line[index];
    }

    public string GetTalk(int id) // 대화
    {
        return Splittxt(id); //해당 아이디의 해당하는 대사를 반환 


    }
    public Sprite GetPortrait(int portraitIndex) // 인물 이미지
    {
        Debug.Log(portraitIndex);
        return imgdata[portraitIndex];
    }
    
    public Sprite getbackground(int bgindex)
    {
        return bgdata[bgindex];
    }

}

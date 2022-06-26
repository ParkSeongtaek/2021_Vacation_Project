using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManagerMJ : MonoBehaviour
{
    enum NowChoiceState
    {
        NotChoiced, Choice1, Choice2
    }
    public TextManager textManager;
    public Fade fade;
    public SaveDataClass saveData;
    public TypingEffect effecting;  // 현재 수정중 텍스트 나올 때 마치 타이핑 되는 것처럼 한글자씩 나오게 하는 효과
    public Text characterName; //캐릭터 이름
    public Text characterSay; //대사창
    public Image characterImg; //캐릭터 이미지
    public GameObject charactershow; //캐릭터 이미지 출력
    public GameObject choiceset; //선택지
    public GameObject nxtbtn; //다음 대사 출력하는 버튼 넘기기버튼
    public GameObject nametag; //이름표
    public GameObject blackset; //프롤로그 검정화면
    public Text blacksay; //검정화면 텍스트
    public Image background; //배경
    public int index;
    public Text choicetxt1;//선택지1번
    public Text choicetxt2;//선택지2번
    int choicenum1;//1번 선택지를 고를 경우 넘어갈 다음 지문 위치
    int choicenum2;//2번 선택지를 고를 경우 넘어갈 다음 지문 위치
    int choice1EndIndex;
    int choice2EndIndex;
    int wholeChoiceEndIndex;
    int nextIndex;
    NowChoiceState nowChoiceState;
    public int nextnum; //다음 지문 위치
    bool isRead; //타이핑 효과 완성되면 사용될 예정, 자동넘기기에서 사용
    private void Start()
    {
        choiceset.SetActive(false);
        blackset.SetActive(false);
        saveData = SaveLoadMgr.instance.saveData;
        nowChoiceState = NowChoiceState.NotChoiced;
        nextIndex = 0;

        Talk();
    }

    //대사 출력
    void Talk()
    {
        int index = nextIndex;
        switch (nowChoiceState)
        {
            case NowChoiceState.Choice1:
                if(index == choice1EndIndex + 1)
                {
                    nextIndex = wholeChoiceEndIndex;
                    index = nextIndex;
                    nowChoiceState = NowChoiceState.NotChoiced;
                }
                break;
            case NowChoiceState.Choice2:
                if(index == choice2EndIndex + 1)
                {
                    nextIndex = wholeChoiceEndIndex;
                    index = nextIndex;
                    nowChoiceState = NowChoiceState.NotChoiced;
                }
                break;
            default:
                break;
        }
        string talkData = textManager.GetTalk(index);
        Debug.Log(talkData);

        string[] txtLine = talkData.Split('\t');
        switch(int.Parse(txtLine[0]))
        {
            case 110: // 배경 o 텍스트 x
                break;
            case 101: // 배경 x 텍스트 o
                blackset.SetActive(true);
                blacksay.text = txtLine[3];
                //SceneMoveMgr.instance.nextindex = int.Parse(txtLine[4]);
                break;
            case 200: // 선택지
                nxtbtn.SetActive(false);//선택지가 띄워져 있을 경우 비활성화
                choiceset.SetActive(true);
                // 선택지의 경우 split[4]에 분기 별 텍스트 줄 갯수 있음.
                // 선택지 2를 골랐을 때 선택지 1의 텍스트 줄 갯수만큼 뛰어넘어서 텍스트 읽음.
                string[] choicedata1 = textManager.GetTalk(index + 1).Split('\t'); 
                choicetxt1.text = choicedata1[3];
                choicenum1 = index + 3; // 분기 알림 1줄 + 선택지 2줄 -> + 3
                choice1EndIndex = choicenum1 + int.Parse(choicedata1[4]) -1;
                string[] choicedata2 = textManager.GetTalk(index + 2).Split('\t');
                choicetxt2.text = choicedata2[3];
                choicenum2 = index + int.Parse(choicedata1[4]) + 3; //사실 + 몇인지 헷갈림. 이후 수정 필요
                choice2EndIndex = choicenum2 + int.Parse(choicedata2[4]) -1;
                wholeChoiceEndIndex= choicenum2 + int.Parse(choicedata2[4]);
                break;
            case 150:
                //미주님 여기 채워주세요
                break;
            case 999: // 씬 이동
                Debug.Log(txtLine[4] + "      " + (int)txtLine[4][0]);
                if (txtLine[4] != "")
                {
                    saveData.nextNovel = txtLine[4];

                    SceneMoveMgr.instance.nextnovel = txtLine[4];
                }
                Debug.Log(saveData.nextNovel);
                Debug.Log(SceneMoveMgr.instance.nextnovel);

                SceneName scene = (SceneName)Enum.Parse(typeof(SceneName), txtLine[3]);
                nextIndex++;
                SceneMoveMgr.instance.LoadScene(scene);

                break;
            default:
                blackset.SetActive(false);
                if (talkData == null)
                {
                    Debug.Log("finish");
                    return;
                }
                effecting.SetMsg(txtLine[3]);
                characterSay.text = txtLine[3]; //대사 출력
                if (int.Parse(txtLine[0]) == 100) // 배경 o 텍스트 o 
                {
                    //지문일 경우 캐릭터 이미지 및 이름표가 출력되지 않음
                    charactershow.SetActive(false); 
                    nametag.SetActive(false);
                } 
                else
                {
                    charactershow.SetActive(true);
                    nametag.SetActive(true);
                    characterName.text = txtLine[1];
                    characterImg.sprite = textManager.GetPortrait(int.Parse(txtLine[0]));
                }
                background.sprite = textManager.getbackground(int.Parse(txtLine[2]));
                isRead = true;charactershow.SetActive(true);
                break;
        }
        nextIndex++;

    }

    // 다음 문장을 출력하는 버튼
    public void nextbtn()
    {
        if (isRead == true)
        {
            isRead = false;
        }
        
        Talk();

    }

    //선택지
    public void choicebtna()
    {
        nowChoiceState = NowChoiceState.Choice1;
        choiceset.SetActive(false);
        nxtbtn.SetActive(true);
        nextIndex = choicenum1;
        Talk();
    }
    public void choicebtnb()
    {
        nowChoiceState = NowChoiceState.Choice2;
        choiceset.SetActive(false);
        nxtbtn.SetActive(true);
        nextIndex = choicenum2;
        Talk();
    }
}

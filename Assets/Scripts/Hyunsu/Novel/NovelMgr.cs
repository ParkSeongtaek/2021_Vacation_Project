using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 자세한 사항은 미주님 스크립트 참고
public class NovelMgr : MonoBehaviour
{
    [SerializeField] public GameObject novelMode;
    [SerializeField] List<Sprite> portraitList;

    public Text characterName;
    public Text characterSay;
    public Image characterImg;
    public GameObject characterShow;
    public GameObject nxtBtn;
    public GameObject nameTag;
    public int index;
    public int nextNum;

    public TextAsset txt;

    public bool isNovelOn;

    void Start()
    {

    }
    public string Splittxt(int index)
    {
        string currentText = txt.text.Substring(0, txt.text.Length - 1);
        string[] line = currentText.Split('\n');
        if (line.Length == index)
        {
            return null;
        }
        return line[index];
    }
    public string GetTalk(int id)
    {
        return Splittxt(id);
    }
    public Sprite GetPortrait(int portraitIndex)
    {
        return portraitList[portraitIndex];
    }
    public void Talk(int index)
    {
        string talkData = GetTalk(index);

        if (talkData == null)
        {
            novelMode.SetActive(false);
            isNovelOn = false;
            return;
        }
        characterSay.text = talkData.Split('\t')[2];
        if (int.Parse(talkData.Split('\t')[0]) == 100)
        {
            // id = 100
            characterShow.SetActive(false);
            nameTag.SetActive(false);
        }
        nextNum = int.Parse(talkData.Split('\t')[3]);
    }
    public void nextBtn()
    {
        Talk(nextNum);
    }
}
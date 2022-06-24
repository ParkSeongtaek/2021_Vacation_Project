using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //controls UI
using UnityEngine.EventSystems;

public class waterBtn : MonoBehaviour
{
    float myWater= 100; // 내 물
    float yourWater= 0; // 네 물
    People nowPeople;

    [SerializeField] public Image myWaterImage; // 내 물 이미지
    [SerializeField] public Image yourWaterImage; // 네 물 이미지
    [SerializeField] public Image myWaterNumImage;
    [SerializeField] public Text waterText;
    [SerializeField] Text DialogueText;
    [SerializeField] Text FailCountText;
    [SerializeField] Text PeopleCountText;
    [SerializeField] Sprite[] peopleSpriteArray;
    [SerializeField] public Image peopleImage;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject parent;
    float waterAmount= 1; // 한 번에 풀 물의 양
    int rqWater= 5;
    int failCount= 0; //실패한 횟수
    int PeopleCount= 1;

    List <People> saram;
    public void Start()
    {
        FailCountText.text= failCount.ToString();
        PeopleCountText.text= PeopleCount.ToString() + " / 5";
        saram= new List<People>();
        for (int i=0; i<5; i++) {
            GameObject ingan;
            People person= new People(Random.Range(0, 4));
            saram.Add(person);
            ingan= Instantiate(prefab, parent.transform);
            ingan.SetActive(true);
            person.human= ingan;
            ingan.GetComponent<RectTransform>().anchoredPosition= new Vector3(150*i, 0, 0);
            ingan.GetComponent<Image>().sprite= peopleSpriteArray[person.indexNum];
        }
        makePeople();
    }

    void makePeople()
    {
        nowPeople= saram[0];
        DialogueText.text= nowPeople.introDialogue;
        peopleImage.sprite= peopleSpriteArray[nowPeople.indexNum];
    }
    
    public void OnClickWaterBtn()
    {
        myWater -= waterAmount;
        yourWater += waterAmount;
        waterText.text= myWater.ToString();
        // 너가 가진 물을 줄임
        // 물 양을 이미지에 반영함
        myWaterNumImage.fillAmount= myWater / 100;
        myWaterImage.fillAmount = myWater / 100;
        yourWaterImage.fillAmount = yourWater / nowPeople.rqWater;
        // 상대방의 물을 늘림
    }

    public void OnClickNextBtn()
    {
        if ((yourWater >= nowPeople.rqWater-1) && (yourWater <= nowPeople.rqWater+1))
        {
            Debug.Log("성공~");
            DialogueText.text= nowPeople.correctDialogue;
        }
        else
        {
            Debug.Log("실패...");
            DialogueText.text= nowPeople.wrongDialogue;
            failCount += 1;
        }
        yourWater = 0;
        PeopleCount += 1;

        FailCountText.text= failCount.ToString();
        PeopleCountText.text= PeopleCount.ToString() + " / 5";

        StartCoroutine(nextPerson());
        
        
    }

    IEnumerator nextPerson() {
        Image humanImage= saram[0].human.GetComponent<Image>();
        float timer= 0;

        Vector3 position= parent.GetComponent<RectTransform>().anchoredPosition;
        Vector3 position1= position - new Vector3(150, 0, 0);
        while (timer < 1) {
            timer+= Time.deltaTime;
            yield return null;
            humanImage.color= new Color (1,1,1, 1-timer);
            parent.GetComponent<RectTransform>().anchoredPosition= Vector3.Lerp(position, position1, timer);
        }
        parent.GetComponent<RectTransform>().anchoredPosition= position1;
        Destroy(saram[0].human);
        saram.RemoveAt(0);
        yield return new WaitForSeconds(2);
       
        makePeople();
    }
    
}

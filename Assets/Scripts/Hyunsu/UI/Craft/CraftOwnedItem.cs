using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftOwnedItem : MonoBehaviour
{
    [SerializeField] GameObject prefab1;
    [SerializeField] GameObject prefab2;
    [SerializeField] GameObject prefab3;
    [SerializeField] GameObject parentObj;
    [SerializeField] GameObject parentObj2;
    [SerializeField] public GameObject makeBtn;
    [SerializeField] CraftingMgr craftMgr;
    [SerializeField] ItemFarmingMgr farmingMgr;


    [SerializeField] public List<GameObject> imgList;   //  제작대에 올라가는 이미지 리스트
    [SerializeField] public List<GameObject> craftInvenItemList;    //  아이템 제작시 인벤 초기화를 위한 리스트
    public int craftOwnedItemNum;
    public int selectedItemNum;
    public bool isMakeBtnActivated;

    public FarmingItemWrapper itemWrapper;
    public Image makeBtnSprite;

    void Start()
    {
        isMakeBtnActivated = false;
        makeBtnSprite = makeBtn.GetComponent<Image>();

        selectedItemNum = 0;

        // 세이브 데이터에서 보유하고 있던 아이템들 인벤토리로 생성
        itemInvenInit();
    }

    // 크래프트 인벤 아이템 프리팹 생성기
    public void craftPrefabInstantiate(int itemNum)
    {
        for (int i = 0; i < farmingMgr.itemList.Count; i++) //  파밍 아이템 전용
        {
            if (itemNum == farmingMgr.itemList[i].num)
            {
                GameObject btn1 = Instantiate(prefab1, parentObj.transform);
               // btn1.transform.localScale = new Vector3(0.2f, 0.2f, 1.0f);

                btn1.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);
                craftInvenItemList.Add(btn1);
                if (craftOwnedItemNum <= 10)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum) * 220), 0, 0);
                }
                else if (craftOwnedItemNum > 10)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum - 10) * 220), -200, 0);
                }
                else if (craftOwnedItemNum > 20)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum - 20) * 220), -400, 0);
                }
                btn1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + farmingMgr.itemList[i].name);
                // 버튼 클릭시 제작대 창으로 옮겨주는거
                btn1.GetComponent<Button>().onClick.AddListener(() => PutCraftWindow(itemNum, btn1));
                // 버튼 클릭시 그 버튼을 비활성화
                btn1.GetComponent<Button>().onClick.AddListener(() => BtnSetActiveFalse(btn1));
                craftOwnedItemNum++;
                break;
            }
        }
        for (int i = 0; i < craftMgr.craftItemList.Count; i++) //  크래프트 아이템 전용
        {
            if (itemNum == craftMgr.craftItemList[i].num)
            {
                GameObject btn1 = Instantiate(prefab1, parentObj.transform);
                btn1.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);
                craftInvenItemList.Add(btn1);
                if (craftOwnedItemNum <= 10)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum) * 220), 0, 0);
                }
                else if (craftOwnedItemNum > 10)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum - 10) * 220), -200, 0);
                }
                else if (craftOwnedItemNum > 20)
                {
                    btn1.GetComponent<RectTransform>().anchoredPosition = new Vector3(-765 + ((craftOwnedItemNum - 20) * 220), -400, 0);
                }
                btn1.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + craftMgr.craftItemList[i].name);
                // 버튼 클릭시 제작대 창으로 옮겨주는거
                btn1.GetComponent<Button>().onClick.AddListener(() => PutCraftWindow(itemNum, btn1));
                // 버튼 클릭시 그 버튼을 비활성화
                btn1.GetComponent<Button>().onClick.AddListener(() => BtnSetActiveFalse(btn1));
                craftOwnedItemNum++;
                break;
            }
        }
    }
    // 선택됨 떠있는 버튼 생성
    public void ChosenBtnPrefabInstantiate(int itemNum, GameObject btn1, GameObject Img)
    {
        for (int i = 0; i < farmingMgr.itemList.Count; i++) //  크래프트 아이템용
        {
            if (itemNum == farmingMgr.itemList[i].num)
            {
                GameObject btn2 = Instantiate(prefab2, parentObj.transform);    //  btn2 >> 아이템이 선택되었을때 내려주는 버튼 인벤에 있음
                craftInvenItemList.Add(btn2);
                btn2.GetComponent<RectTransform>().anchoredPosition = btn1.GetComponent<RectTransform>().anchoredPosition;
                //btn2.GetComponent<Image>().sprite = Resources.Load<Sprite>("");
                btn2.GetComponent<Image>().sprite = null;

                // 아이템을 제작대에서 내려주는 버튼효과
                btn2.GetComponent<Button>().onClick.AddListener(() => RemoveItem(itemNum, btn1, btn2, Img));
                break;
            }
        }
        for (int i = 0; i < craftMgr.craftItemList.Count; i++) //  파밍 아이템용
        {
            if (itemNum == craftMgr.craftItemList[i].num)
            {
                GameObject btn2 = Instantiate(prefab2, parentObj.transform);    //  btn2 >> 아이템이 선택되었을때 내려주는 버튼 인벤에 있음
                craftInvenItemList.Add(btn2);
                btn2.GetComponent<RectTransform>().anchoredPosition = btn1.GetComponent<RectTransform>().anchoredPosition;
                //btn2.GetComponent<Image>().sprite = Resources.Load<Sprite>("");
                btn2.GetComponent<Image>().sprite = null;
                // 아이템을 제작대에서 내려주는 버튼효과
                btn2.GetComponent<Button>().onClick.AddListener(() => RemoveItem(itemNum, btn1, btn2, Img));
                break;
            }
        }
    }

    // 제작대에 선택한 아이템 이미지 띄워주기
    public GameObject ImgInstantiateOnWindow(int itemNum)
    {
        GameObject Img = null;
        for (int i = 0; i < farmingMgr.itemList.Count; i++) //  파밍 아이템용
        {
            if (itemNum == farmingMgr.itemList[i].num)
            {
                Img = Instantiate(prefab3, parentObj2.transform);
                Img.GetComponent<RectTransform>().anchoredPosition = new Vector3(-400 + selectedItemNum * 200, 0, 0);
                Img.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + farmingMgr.itemList[i].name);
                imgList.Add(Img);
                selectedItemNum = craftMgr.ItemOnCraftList.Count;
                break;
            }
        }
        for (int i = 0; i < craftMgr.craftItemList.Count; i++) //  크래프트 아이템용
        {
            if (itemNum == craftMgr.craftItemList[i].num)
            {
                Img = Instantiate(prefab3, parentObj2.transform);
                Img.GetComponent<RectTransform>().anchoredPosition = new Vector3(-400 + selectedItemNum * 200, 0, 0);
                Img.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + craftMgr.craftItemList[i].name);
                imgList.Add(Img);
                selectedItemNum = craftMgr.ItemOnCraftList.Count;
                break;
            }
        }
        return Img;
    }

    // 아이템 클릭하면 제작대로 옮겨주는거
    public void PutCraftWindow(int itemNum, GameObject btn)
    {
        craftMgr.ItemOnCraftList.Add(itemNum);
        GameObject Img = ImgInstantiateOnWindow(itemNum);
        ChosenBtnPrefabInstantiate(itemNum, btn, Img);

        int itemCount = 0;

        // 아이템을 올릴때 제작식이랑 비교해서 올바른 아이템이 올라갔을시 만들기 버튼 활성화
        for (int i = 0; i < craftMgr.craftItemList.Count; i++)
        {
            if (craftMgr.craftItemList[i].matItemList.Count == craftMgr.ItemOnCraftList.Count)
            {
                for (int j = 0; j < craftMgr.ItemOnCraftList.Count; j++)
                {
                    if (craftMgr.craftItemList[i].matItemList.Contains(craftMgr.ItemOnCraftList[j]))
                    {
                        itemCount++;
                    }
                }
            }
        }
        if (itemCount == craftMgr.ItemOnCraftList.Count)
        {
            //makeBtnSprite.sprite = Resources.Load<Sprite>("Hyunsu/UI/make_after");
            makeBtn.GetComponent<Button>().interactable = true;
            isMakeBtnActivated = true;
        }
        else
        {
            //makeBtnSprite.sprite = Resources.Load<Sprite>("Hyunsu/UI/make_before");
            makeBtn.GetComponent<Button>().interactable = false;
            isMakeBtnActivated = false;
        }
    }

    // 아이템을 제작대에서 내려주는 버튼
    public void RemoveItem(int itemNum, GameObject btn1, GameObject btn2, GameObject Img)
    {
        btn1.SetActive(true);
        imgList.Remove(Img);
        Destroy(Img);
        Destroy(btn2);
        // 제작대 리스트에 있는 선택한 아이템을 뺴주기
        craftMgr.ItemOnCraftList.Remove(itemNum);
        selectedItemNum = craftMgr.ItemOnCraftList.Count;
        // 하나 빠지면 하나씩 앞으로 땅겨주기
        for (int i = 0; i < imgList.Count; i++)
        {
            imgList[i].GetComponent<RectTransform>().anchoredPosition = new Vector3(-400 + 200 * i, 0, 0);
        }

        // 아이템이 조합식에 맞게 올려졌을때만 make버튼 활성화 하도록
        if (craftMgr.ItemOnCraftList.Count == 0)
        {
            //makeBtnSprite.sprite = Resources.Load<Sprite>("Hyunsu/UI/make_before");
            makeBtn.GetComponent<Button>().interactable = false;
            return;
        }
        int itemCount = 0;
        for (int i = 0; i < craftMgr.craftItemList.Count; i++)
        {
            if (craftMgr.craftItemList[i].matItemList.Count == craftMgr.ItemOnCraftList.Count)
            {
                for (int j = 0; j < craftMgr.ItemOnCraftList.Count; j++)
                {
                    if (craftMgr.craftItemList[i].matItemList.Contains(craftMgr.ItemOnCraftList[j]))
                    {
                        itemCount++;
                    }
                }
            }
        }
        if (itemCount == craftMgr.ItemOnCraftList.Count)
        {
            //makeBtnSprite.sprite = Resources.Load<Sprite>("Hyunsu/UI/make_after");
            makeBtn.GetComponent<Button>().interactable = true;
            isMakeBtnActivated = true;
        }
        else
        {
            //makeBtnSprite.sprite = Resources.Load<Sprite>("Hyunsu/UI/make_before");
            makeBtn.GetComponent<Button>().interactable = false;
            isMakeBtnActivated = false;
        }
    }

    public void itemInvenInit() //  인벤토리 가지고 있는 아이템들로 초기화
    {
        // 세이브 데이터에서 보유하고 있던 아이템들 인벤토리로 생성
        craftOwnedItemNum = 0;
        for (int i = 0; i < SaveLoadMgr.instance.saveData.ownedItemList.Count; i++)
        {
            craftPrefabInstantiate(SaveLoadMgr.instance.saveData.ownedItemList[i]);
        }
    }

    // 버튼 비활성화 함수 (만들고 보니 이게 필요한가 싶다 나중에 바꿔주기)
    public void BtnSetActiveFalse(GameObject btn)
    {
        btn.SetActive(false);
    }
}

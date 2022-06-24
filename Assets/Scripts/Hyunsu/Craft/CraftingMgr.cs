using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CraftingMgr : MonoBehaviour
{
    [SerializeField] public List<CraftedItemClass> craftItemList;    // 완제품 리스트
    [SerializeField] public List<int> ItemOnCraftList; //  현재 제작대에 올려져 있는 아이템
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject parentObj;
    [SerializeField] GameObject craftedItemPrefab;
    [SerializeField] GameObject craftedParentObj;
    [SerializeField] CraftOwnedItem craftOwnItem;
    [SerializeField] OwnedItem farmingOwnItem;
    [SerializeField] WorldInvenManager worldItemMgr;

    CraftedItemWrapper wrapper;

    JsonMgr json;
    void Start()
    {
        worldItemMgr = FindObjectOfType<WorldInvenManager>();

        craftItemList = worldItemMgr.craftItemList;

        // 완제품 리스트 받아옴
        //json = new JsonMgr();
        //wrapper = json.ResourceDataLoad<CraftedItemWrapper>("CraftedItemDataList");
        //craftItemList = wrapper.craftedItemList;

        ItemOnCraftList = new List<int>();
    }

    // 아이템 조합기
    public void ItemCrafting(List<int> itemList)
    {
        // 지역변수 itemList는 현재 올려져 있는 아이템 리스트임
        // craftItemList는 완제품 리스트 데이터임

        for (int i = 0; i < craftItemList.Count; i++)
        {
            int itemCount = 0;
            if (craftItemList[i].matItemList.Count == ItemOnCraftList.Count)
            {
                for (int j = 0; j < ItemOnCraftList.Count; j++)
                {
                    if (craftItemList[i].matItemList.Contains(ItemOnCraftList[j]))
                    {
                        itemCount++;
                    }
                    if (itemCount == ItemOnCraftList.Count)
                    {
                        int para = i;
                        int thisNum =  craftItemList[i].num;
                        //Debug.Log("만든 아이템" + thisNum);
                        craftOwnItem.makeBtn.GetComponent<Button>().interactable = false;

                        //아이템 획득하는 버튼 만들기
                        GameObject craftedBtn = Instantiate(craftedItemPrefab, craftedParentObj.transform);
                        craftedBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + craftItemList[i].name);
                        craftedBtn.GetComponent<Button>().onClick.AddListener(() => itemGetPrefab(para, craftedBtn));
                        craftedBtn.GetComponent<RectTransform>().sizeDelta = new Vector2(150f, 150f);

                        //사용한 아이템들 파밍 인벤에서 없애고 만들어진 아이템 인벤토리로 넣어주기

                        //SaveLoadMgr.instance.saveData.ownedItemList.Add(craftItemList[i].num);

                        for (int k = 0; k < ItemOnCraftList.Count; k++)
                        {
                            Destroy(craftOwnItem.imgList[k]);   // 제작대에 올려져 있는 오브젝트들 파괴
                            SaveLoadMgr.instance.saveData.usedItemList.Add(ItemOnCraftList[k]); //  사용한 아이템 리스트에 넣어줌
                            SaveLoadMgr.instance.saveData.ownedItemList.Remove(ItemOnCraftList[k]); //  사용된 아이템 보유아이템 리스트에서 빼줌
                        }
                        craftOwnItem.imgList.Clear();   //  제작대 이미지 리스트 초기화
                        craftOwnItem.selectedItemNum = 0;   //  선택된 아이템 개수 초기화

                        for (int k = 0; k < craftOwnItem.craftInvenItemList.Count; k++)
                        {
                            Destroy(craftOwnItem.craftInvenItemList[k]);    //  제작시 사용된 아이템들 부셔버려
                
                        }
                        craftOwnItem.itemInvenInit();    // 크래프트 인벤에서 아이템 가지고 있는것만 다시 생성

                        for (int k = 0; k < farmingOwnItem.farmingInvenItemList.Count; k++)
                        {
                            Destroy(farmingOwnItem.farmingInvenItemList[k]);    //  제작시 사용된 아이템들 뿌셔뿌셔
                        }
                        farmingOwnItem.farmingInvenInit();    // 파밍 인벤에서 아이템 가지고 있는것만 다시 생성

                        // 월드 인벤에 사용한 아이템 없애


                        ItemOnCraftList.Clear();    //  제작대 올라간 아이템 리스트 초기화

                        break;
                    }
                }
            }
        }
    }

    public void itemGetPrefab(int i, GameObject btn)
    { 
        SaveLoadMgr.instance.saveData.ownedItemList.Add(craftItemList[i].num);


        for (int k = 0; k < ItemOnCraftList.Count; k++)
        {
            Destroy(craftOwnItem.imgList[k]);   // 제작대에 올려져 있는 오브젝트들 파괴
            SaveLoadMgr.instance.saveData.usedItemList.Add(ItemOnCraftList[k]); //  사용한 아이템 리스트에 넣어줌
            SaveLoadMgr.instance.saveData.ownedItemList.Remove(ItemOnCraftList[k]); //  사용된 아이템 보유아이템 리스트에서 빼줌
        }
        craftOwnItem.imgList.Clear();   //  제작대 이미지 리스트 초기화
        craftOwnItem.selectedItemNum = 0;   //  선택된 아이템 개수 초기화
        for (int k = 0; k < craftOwnItem.craftInvenItemList.Count; k++)
        {
            Destroy(craftOwnItem.craftInvenItemList[k]);    //  제작시 사용된 아이템들 부셔버려
        }
        craftOwnItem.itemInvenInit();    // 크래프트 인벤에서 아이템 가지고 있는것만 다시 생성
        for (int k = 0; k < farmingOwnItem.farmingInvenItemList.Count; k++)
        {
            Destroy(farmingOwnItem.farmingInvenItemList[k]);    //  제작시 사용된 아이템들 뿌셔뿌셔
        }
        farmingOwnItem.farmingInvenInit();    // 파밍 인벤에서 아이템 가지고 있는것만 다시 생성

        ItemOnCraftList.Clear();    //  제작대 올라간 아이템 리스트 초기화
        // 월드인벤에 만든 아이템 넣어준다
        worldItemMgr.WorldnvenAdd(craftItemList[i].num);

        Destroy(btn);
    }
}

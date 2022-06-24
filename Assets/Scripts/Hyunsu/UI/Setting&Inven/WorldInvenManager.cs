using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class WorldInvenManager : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject parentObj;

    // 아이템 리스트들
    // 여기서 아이템 리스트 만들어놨음
    // 파밍과 크래프트 매니저의 아이템 리스트 여기서 불러옴
    public List<FarmingItemClass> farmingItemList;
    public List<CraftedItemClass> craftItemList;

    [SerializeField] public  List<GameObject> worldOwnItem;

    JsonMgr json;
    FarmingItemWrapper farmingItemWrapper;
    CraftedItemWrapper craftItemWrapper;

    void Start()
    {

        json = new JsonMgr();

        farmingItemWrapper = json.ResourceDataLoad<FarmingItemWrapper>("FarmingItemDataList");
        farmingItemList = farmingItemWrapper.farmingItemList;

        craftItemWrapper = json.ResourceDataLoad<CraftedItemWrapper>("CraftedItemDataList");
        craftItemList = craftItemWrapper.craftedItemList;

    }

    void Update()
    {
        
    }

    public void WorldnvenAdd(int itemNum)
    {
        Debug.Log(itemNum);
        GameObject obj;
        if (itemNum < 100)  // 100번 이하는 파밍 아이템
        {
            for (int i = 0; i < farmingItemList.Count; i++)
            {
                if (farmingItemList[i].num == itemNum)
                {
                    Debug.Log(itemNum);
                    obj = Instantiate(prefab, parentObj.transform);
                    obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + farmingItemList[i].name);
                    worldOwnItem.Add(obj);
                    obj.GetComponent<Button>().onClick.AddListener(() => PrintTooltip(itemNum));

                    if (worldOwnItem.Count <= 6)
                    {
                        if ((worldOwnItem.Count % 6) <= 3)   // 첫번째 줄
                        {
                            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-345 + ((worldOwnItem.Count - 1) % 3) * 340, 180, 0);
                        }
                        else // 두번째 줄
                        {
                            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-345 + ((worldOwnItem.Count - 1) % 3) * 340, -175, 0);
                        }
                    }
                    // 두번째 페이지 나중에 만들어줄것
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < craftItemList.Count; i++)
            {
                if (craftItemList[i].num == itemNum)
                {
                    obj = Instantiate(prefab, parentObj.transform);
                    obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + craftItemList[i].name);
                    worldOwnItem.Add(obj);
                    obj.GetComponent<Button>().onClick.AddListener(() => PrintTooltip(itemNum));

                    if (worldOwnItem.Count <= 6)
                    {
                        if ((worldOwnItem.Count % 6) < 3)   // 첫번째 줄
                        {
                            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-345 + ((worldOwnItem.Count - 1) % 3) * 340, 180, 0);
                        }
                        else // 두번째 줄
                        {
                            obj.GetComponent<RectTransform>().anchoredPosition = new Vector3(-345 + ((worldOwnItem.Count - 1) % 3) * 340, -175, 0);

                        }
                    }

                    break;
                }

            }
        }
    }
    public void PrintTooltip(int itemNum)
    {
        if (itemNum < 100)
        {
            for (int i = 0; i < farmingItemList.Count; i++)
            {
                if (farmingItemList[i].num == itemNum)
                {
                    Debug.Log(farmingItemList[i].tooltip);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < craftItemList.Count; i++)
            {
                if (craftItemList[i].num == itemNum)
                {
                    Debug.Log(craftItemList[i].tooltip);
                    break;
                }
            }
        }
    }

    public void WorldInvenRemove()
    {

    }

    public void WorldInvenInit()
    {
        for (int i = 0; i < SaveLoadMgr.instance.saveData.ownedItemList.Count; i++)
        {
            WorldnvenAdd(SaveLoadMgr.instance.saveData.ownedItemList[i]);
        }
    }
}
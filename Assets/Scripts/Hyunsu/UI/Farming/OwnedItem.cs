using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using UnityEngine.UI;

// 지금 보유하고 있는 아이템
public class OwnedItem : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject parentObj;
    [SerializeField] ItemFarmingMgr farmingMgr;
    [SerializeField] CraftingMgr craftMgr;
    [SerializeField] public List<GameObject> farmingInvenItemList;  //  아이템 제작시 인벤 초기화를 위한 리스트

    void Start()
    {
        // 세이브 데이터에서 보유하고 있던 아이템들 인벤토리로 생성
        farmingInvenInit();
    }


    // 파밍 인벤 아이템 프리팹 생성기
    public void prefabInstantiate(int itemNum)
    {
        for (int i = 0; i < farmingMgr.itemList.Count; i++) //  파밍 아이템용
        {
            if (farmingMgr.itemList[i].num == itemNum)
            {
                GameObject obj = Instantiate(prefab, parentObj.transform);
                farmingInvenItemList.Add(obj);
                obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + farmingMgr.itemList[i].name);
                break;
            }
        }
        for (int i = 0; i < craftMgr.craftItemList.Count; i++) //  크래프트 아이템용
        {
            if (craftMgr.craftItemList[i].num == itemNum)
            {
                GameObject obj = Instantiate(prefab, parentObj.transform);
                farmingInvenItemList.Add(obj);
                obj.GetComponent<Image>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + craftMgr.craftItemList[i].name);
                break;
            }
        }
    }
    public void farmingInvenInit()
    {
        for (int i = 0; i < SaveLoadMgr.instance.saveData.ownedItemList.Count; i++)
        {
            prefabInstantiate(SaveLoadMgr.instance.saveData.ownedItemList[i]);
        }
    }
}

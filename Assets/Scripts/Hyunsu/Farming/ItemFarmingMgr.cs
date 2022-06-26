using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemFarmingMgr : MonoBehaviour
{
    [SerializeField] public List<FarmingItemClass> itemList;   //전체 파밍 아이템 리스트
    [SerializeField] GameObject prefabs;    //  아이템 프리팹
    [SerializeField] CraftOwnedItem craftOwnedItem; // 크래프트 모드 인벤의 아이템
    [SerializeField] OwnedItem ownedItem;   //  파밍 모드 인벤의 아이템
    [SerializeField] NovelMgr novelMgr;
    WorldInvenManager worldInvenMgr;
    public FarmingItemWrapper itemWrapper;

    // 스프라이트 인식
    public Camera cam;
    RaycastHit2D hit;
    public GameObject touchedObj;
    Dictionary<int, bool> IsMoveScene;


    JsonMgr json;
    public int thisNum;
    void Start()
    {
        worldInvenMgr = FindObjectOfType<WorldInvenManager>();

        // 아이템 리스트 받아옴
        //json = new JsonMgr();
        //itemWrapper = json.ResourceDataLoad<FarmingItemWrapper>("FarmingItemDataList");
        //itemList = itemWrapper.farmingItemList;


        itemList = worldInvenMgr.farmingItemList;
        // 파밍해야 하는 아이템들 생성
        
        farmingItemInit();

       

    }

    void Update()
    {
        if (novelMgr.isNovelOn == false)
        {
            // 아이템 클릭시 스프라이트 인식
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
                hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit.collider != null)
                {
                    touchedObj = hit.collider.gameObject;

                    // touchedObj를 아이템 리스트에서 검색
                    for (int i = 0; i < itemList.Count; i++)
                    {
                        if (touchedObj == itemList[i].aimObj)
                        {
                            thisNum = itemList[i].num;
                            // 아이템 클릭시 데이터 파일의 아이템 리스트에 추가
                            SaveLoadMgr.instance.saveData.ownedItemList.Add(itemList[i].num);
                            Destroy(touchedObj);

                            // 아이템 획득시 아이템 인벤토리에 프리팹 생성
                            ownedItem.prefabInstantiate(itemList[i].num);
                            craftOwnedItem.craftPrefabInstantiate(itemList[i].num);

                            // 월드 인벤 프리팹 생성해주기
                            worldInvenMgr.WorldnvenAdd(thisNum);


                            novelMgr.novelMode.SetActive(true);
                            novelMgr.isNovelOn = true;
                            novelMgr.txt = Resources.Load<TextAsset>("Hyunsu/Item/" + itemList[i].name);
                            novelMgr.Talk(0);


                        }
                    }
                }

            }
        }
        
    }
    public bool CustomEndsWith(string a, string b)
    {
        int ap = a.Length - 1;
        int bp = b.Length - 1;



        while (ap >= 0 && bp >= 0 && a[ap] == b[bp])
        {
            ap--;
            bp--;
        }

        return (bp < 0);
    }

    
    public void farmingItemInit()
    {
        Debug.Log("진입");
        for (int p = 0; p < SaveLoadMgr.instance.saveData.nextNovel.Length; p++)
        {
            Debug.Log(SaveLoadMgr.instance.saveData.nextNovel[p]);
            Debug.Log((int)SaveLoadMgr.instance.saveData.nextNovel[p]);

        }
        for (int i = 0; i < itemList.Count; i++)
        {
            bool isContain = false;
            bool isUsed = false;
            for (int j = 0; j < SaveLoadMgr.instance.saveData.ownedItemList.Count; j++)
            {
                if (itemList[i].num == SaveLoadMgr.instance.saveData.ownedItemList[j])
                {
                    isContain = true;
                    break;
                }
            }
            for (int j = 0; j < SaveLoadMgr.instance.saveData.usedItemList.Count; j++)
            {
                if (itemList[i].num == SaveLoadMgr.instance.saveData.usedItemList[j])
                {
                    isUsed = true;
                    break;
                }
            }
            if (!isContain && !isUsed)
            {



                for (int p = 0; p < itemList[i].NextNovel.Length; p++)
                {
                    Debug.Log(itemList[i].NextNovel[p]);
                    Debug.Log((int)itemList[i].NextNovel[p]);

                }


                if (SaveLoadMgr.instance.saveData.nextNovel==itemList[i].NextNovel) {
                    Debug.Log("아이템 생성생성");

                    GameObject obj = Instantiate(prefabs);
                    obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Hyunsu/Item/" + itemList[i].name);
                    obj.transform.localScale = itemList[i].itemSize;
                    Destroy(obj.transform.GetComponent<BoxCollider2D>());
                    obj.AddComponent<BoxCollider2D>();
                    if(itemList[i].num == 5)
                    {
                        obj.AddComponent<SceneMoveItem>();
                    }
                    obj.transform.Rotate(itemList[i].itemRotate);
                    obj.transform.position = itemList[i].itemVec;
                  
                    itemList[i].aimObj = obj;
                }
            }
        }
    }
}

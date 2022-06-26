using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//각 파밍 장소 위치
// 집 내부 0, 0
// 집 바깥 30, 0
// 저잣거리 60, 0
// 주막 0, -15
// 주막 창고 30, -15

// 파밍모드 화면 좌우로 움직이게 하는거
public class PlaceMover : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] Text current;

    [SerializeField] GameObject indoor;
    [SerializeField] GameObject outdoor;
    [SerializeField] GameObject street;
    [SerializeField] GameObject inn;
    [SerializeField] GameObject innStorage;

    private void Start()
    {


        cam.transform.position = new Vector3(0f, 0f, -10f);
        /*
        indoor.SetActive(true);
        current.text = "성준영 집 안";
        outdoor.SetActive(false);
        street.SetActive(false);
        inn.SetActive(false);
        innStorage.SetActive(false);
        */

        StartLocation(SaveLoadMgr.instance.saveData.nextNovel);

        
    }



    public void IndoorToOutdoor()
    {
        current.text = "성준영 집 밖";
        cam.transform.position = new Vector3(30f, 0f, -10f);
        indoor.SetActive(false);
        outdoor.SetActive(true);
    }
    public void OutdoorToIndoor()
    {
        current.text = "성준영 집 안";
        cam.transform.position = new Vector3(0f, 0f, -10f);
        outdoor.SetActive(false);
        indoor.SetActive(true);
    }
    public void OutdoorToStreet()
    {
        current.text = "저잣거리";
        cam.transform.position = new Vector3(60f, 0f, -10f);
        outdoor.SetActive(false);
        street.SetActive(true);
    }
    public void StreetToOutdoor()
    {
        current.text = "성준영 집 밖";
        cam.transform.position = new Vector3(30f, 0f, -10f);
        street.SetActive(false);
        outdoor.SetActive(true);
    }
    public void StreetToInn()
    {
        current.text = "주막";
        cam.transform.position = new Vector3(0f, -15f, -10f);
        street.SetActive(false);
        inn.SetActive(true);
       
    }
    public void InnToStreet()
    {
        current.text = "저잣거리";
        cam.transform.position = new Vector3(60f, 0f, -10f);
        inn.SetActive(false);
        street.SetActive(true);
    }
    public void InnToStorage()
    {
        current.text = "주막 창고";
        cam.transform.position = new Vector3(30f, -15f, -10f);
        inn.SetActive(false);
        innStorage.SetActive(true);
    }
    public void StorageToInn()
    {
        current.text = "주막";
        cam.transform.position = new Vector3(0f, -15f, -10f);
        innStorage.SetActive(false);
        inn.SetActive(true);
        if (SaveLoadMgr.instance.saveData.nextNovel == "찐 prologue2")
        {
            inn.transform.GetChild(0).gameObject.SetActive(false);

            if (SaveLoadMgr.instance.saveData.FindOwnedItem(6))
            {
                SceneMoveMgr.instance.LoadScene(1);
            }
        }
    }


    void StartLocation(string Scene)
    {
        if (Scene == "찐 prologue2")
        {
            StorageToInn();
        }
        else if(Scene == "prologue3\r")
        {
            current.text = "부엌";
            cam.transform.position = new Vector3(60f, -15f, -10f);

        }

    }

    

}

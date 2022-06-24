using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour
{
    [SerializeField] GameObject farming;
    [SerializeField] GameObject craft;
    [SerializeField] Camera cam;
    Vector3 beforeVec;
    void Start()
    {
        farming.SetActive(true);
        craft.SetActive(false);
        beforeVec = new Vector3(0, 0, 0);
    }

    // 파밍 -> 크래프트
    public void OnClickCraftBtn()
    {
        beforeVec = cam.transform.position;
        cam.transform.position = new Vector3(0, 15, -10);
        farming.SetActive(false);
        craft.SetActive(true);
    }
    // 크래프트 -> 파밍
    public void OnClickExitBtn()
    {
        cam.transform.position = beforeVec;
        craft.SetActive(false);
        farming.SetActive(true);
    }
}

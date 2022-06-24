using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenNext : MonoBehaviour
{
    [SerializeField] GameObject before;
    [SerializeField] GameObject next;
    [SerializeField] GameObject contents;
    [SerializeField] GameObject craftBefore;
    [SerializeField] GameObject craftNext;
    [SerializeField] GameObject craftContents;

    private void Start()
    {
        contents.GetComponent<RectTransform>().anchoredPosition = new Vector3(0f, 0f, 0f);
    }
    public void beforeBtn()
    {
        // 마지막 페이지에 있을때 이전 버튼 누를시 다음 버튼 활성화
        if (contents.GetComponent<RectTransform>().anchoredPosition.y == 400f)
        {
            next.SetActive(true);
        }
        // 첫 페이지의 한칸 앞에 있을 때 이전 버튼 누를시 이전 버튼 비활성화
        if (contents.GetComponent<RectTransform>().anchoredPosition.y == 200f)
        {
            before.SetActive(false);
        }
        contents.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
            contents.GetComponent<RectTransform>().anchoredPosition.y - 200, 0);
    }

    public void nextBtn()
    {
        // 첫 페이지에 있을때 다음 버튼 누를시 이전 버튼 활성화
        if (contents.GetComponent<RectTransform>().anchoredPosition.y == 0)
        {
            before.SetActive(true);
        }
        // 마지막 페이지의 한칸 전에 있을 때 다음 버튼 누를시 다음 버튼 비활성화
        if (contents.GetComponent<RectTransform>().anchoredPosition.y == 200f)
        {
            next.SetActive(false);
        }
        contents.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
            contents.GetComponent<RectTransform>().anchoredPosition.y + 200, 0);
    }

    public void craftBeforeBtn()
    {
        // 마지막 페이지에 있을때 이전 버튼 누를시 다음 버튼 활성화
        if (craftContents.GetComponent<RectTransform>().anchoredPosition.y == 400)
        {
            craftNext.SetActive(true);
        }
        // 첫 페이지의 한칸 앞에 있을 때 이전 버튼 누를시 이전 버튼 비활성화
        if (craftContents.GetComponent<RectTransform>().anchoredPosition.y == 200)
        {
            craftBefore.SetActive(false);
        }
        craftContents.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
            craftContents.GetComponent<RectTransform>().anchoredPosition.y - 200, 0);
    }

    public void craftNextBtn()
    {
        // 첫 페이지에 있을때 다음 버튼 누를시 이전 버튼 활성화
        if (craftContents.GetComponent<RectTransform>().anchoredPosition.y == 0)
        {
            craftBefore.SetActive(true);
        }
        // 마지막 페이지의 한칸 전에 있을 때 다음 버튼 누를시 다음 버튼 비활성화
        if (craftContents.GetComponent<RectTransform>().anchoredPosition.y == 200)
        {
            craftNext.SetActive(false);
        }
        craftContents.GetComponent<RectTransform>().anchoredPosition = new Vector3(0,
            craftContents.GetComponent<RectTransform>().anchoredPosition.y + 200, 0);
    }
}

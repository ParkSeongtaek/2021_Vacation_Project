using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InvenUI : MonoBehaviour
{
    [SerializeField] GameObject upBtn;
    [SerializeField] GameObject downBtn;
    [SerializeField] GameObject invenUI;

    Vector2 upVec;
    Vector2 downVec;

    void Start()
    {
        upVec = new Vector2(0f, 0f);
        downVec = new Vector2(0f, -245f);
    }

    void Update()
    {

    }
    IEnumerator InvenMover(Vector2 vec1, Vector2 vec2)
    {

        float timer = 0;
        while(timer < 1)
        {
            invenUI.GetComponent<RectTransform>().anchoredPosition = Vector2.Lerp(vec1, vec2, timer);
            timer += Time.deltaTime * 5;
            yield return null;
        }
    }
    public void DownToUpBtn()
    {
        upBtn.SetActive(true);
        downBtn.SetActive(false);
        StartCoroutine(InvenMover(downVec, upVec));
    }
    public void UpToDownBtn()
    {
        downBtn.SetActive(true);
        upBtn.SetActive(false);
        StartCoroutine(InvenMover(upVec, downVec));
    }
}
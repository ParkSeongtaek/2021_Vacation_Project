using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartFadeCouroutine()
    {
        StartCoroutine(Faderoutine());
            Debug.Log("Fade Out...");
    }

    IEnumerator Faderoutine() // 페이드 아웃 코루틴
    {
        float fadeCount = 0; //투명도(알파값) 초기 설정
        while (fadeCount < 1.0f) //알파값 255가 될 때까지
        {
            fadeCount += 0.1f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadeCount);
        }
    }
    

}

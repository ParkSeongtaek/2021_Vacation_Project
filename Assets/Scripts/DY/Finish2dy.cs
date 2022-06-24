using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish2dy : MonoBehaviour
{
    public Fade fade;
    void Start()
    {

    }
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("MISSION SUCCESS!"); // 골인 지점 도착 -> gameEnd
            fade.StartFadeCouroutine(); //페이드 아웃 시작
            SceneMoveMgr.instance.LoadScene(SceneName.NovelScene);
            Debug.Log("next scene");
        }
       
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finishdy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HealthGaugedy.health == 0)
        {
            Debug.Log("MISSION FAILED...");
            SceneMoveMgr.instance.LoadScene(SceneName.NovelScene);
            Debug.Log("next scene");
            //골인 지점 도착 전에 체력이 떨어진 경우 -> gameEnd
        }
    }
}

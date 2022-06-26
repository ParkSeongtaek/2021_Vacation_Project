using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveItem : MonoBehaviour
{

    void OnDestroy()
    {
       
        SceneMoveMgr.instance.LoadScene(1);
    }
    
}

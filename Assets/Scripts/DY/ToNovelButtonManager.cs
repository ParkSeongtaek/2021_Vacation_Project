using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToNovelButtonManager : MonoBehaviour
{
    public void NovelSceneButton()
    {
        SceneMoveMgr.instance.LoadScene(SceneName.NovelScene);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fmode : MonoBehaviour
{
    public SaveDataClass saveData;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(saveData.nextNovel);
        Debug.Log(SceneMoveMgr.instance.nextnovel);
    }

    public void moverscene()
    {

        SceneManager.LoadScene("Prologue");
    }
}

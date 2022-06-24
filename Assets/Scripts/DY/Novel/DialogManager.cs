using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    JsonMgr json;
    DialogBundle dialogBundle;
    public List<Dialog> dialogList;
    public Text inputText, charNameText;
    public int textPos = 0;
    public Image backgroundFile;
    bool goOn = true;
    public int scriptNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        json = new JsonMgr();
        if (scriptNum == 0)
        {
            dialogBundle = json.ResourceDataLoad<DialogBundle>("PrologueFirst");
        }
        else if (scriptNum == 1)
        {
            dialogBundle = json.ResourceDataLoad<DialogBundle>("PrologueSecond");
        }
        dialogList = dialogBundle.dialogList;
        //PrintDialog();
    }

    // Update is called once per frame
    void Update()
    {
        
        //inputText.text = dialogList[i].narationDialog;
        if (Input.GetMouseButtonDown(0) && goOn)
        {
            goOn = false;
            if (dialogList[textPos].backGroundFileName != null)
            {
                ChangeBackgroundFile();
            }

            if (dialogList[textPos].narationDialog != null)
            {
                charNameText.text = dialogList[textPos].character;
                inputText.text = dialogList[textPos].narationDialog;
                //textPos++;
            }
            else
            {
                if (dialogList[textPos].character != null)
                {
                    charNameText.text = dialogList[textPos].character; //
                }
                inputText.text = dialogList[textPos].characterDialog;
                //textPos++;
            }

            if (dialogList[textPos].actionKeyword == "GoToFarmingMode")
            {
                StartCoroutine(PlayFarmingMode());
            }  
            textPos++;
            goOn = true;
            //AddDialogNum();
        }

    }

    IEnumerator PlayFarmingMode()
    {
        //Debug.Log("ddd");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("FarmingScene");
    }
    void ChangeBackgroundFile()
    {
        backgroundFile.sprite = Resources.Load<Sprite>("Background/" + dialogList[textPos].backGroundFileName);
    }

    void AddDialogNum()
    {
        if (dialogList[textPos + 1] == null)
        {
            scriptNum++;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting : MonoBehaviour
{
    public GameObject SettingImg;
    public GameObject Setbtn;
    public GameObject Invenbtn;
    public GameObject InvenImg;
    bool setisOpen=false;
    bool invenIsOpen = false;
    // Start is called before the first frame update
    private void Start()
    {
        SettingImg.SetActive(false);
        InvenImg.SetActive(false);
    }
    public void ClickSetting()
    {
        if (setisOpen == false)
        {
            SettingImg.SetActive(true);
            Setbtn.SetActive(false);
            Invenbtn.SetActive(false);
            setisOpen = true;
        }
        else
        {
            SettingImg.SetActive(false);
            Setbtn.SetActive(true);
            Invenbtn.SetActive(true);
            setisOpen = false;
        }
    }
    public void ClickInven()
    {
        if (invenIsOpen == false)
        {
            InvenImg.SetActive(true);
            invenIsOpen = true;
        }
        else if (invenIsOpen == true)
        {
            InvenImg.SetActive(false);
            invenIsOpen = false;
        }
    }
}

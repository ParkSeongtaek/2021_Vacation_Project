using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setting_Inven : MonoBehaviour
{
    public static Setting_Inven instance;
    public GameObject SettingImg;
    public GameObject Setbtn;
    public GameObject Invenbtn;
    public GameObject InvenImg;
    bool setisOpen = false;
    bool invenIsOpen = false;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

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
    public void InvenClose()
    {
        InvenImg.SetActive(false);
        invenIsOpen = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMgr : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Setting_Inven.instance.Setbtn.SetActive(true);
        Setting_Inven.instance.Invenbtn.SetActive(true);
    }
}

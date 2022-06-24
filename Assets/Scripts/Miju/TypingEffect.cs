using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingEffect : MonoBehaviour
{
    public int sec;
    string targetMsg;
    Text msgText;
    int index;
    float interval;
    public void Awake()
    {
        msgText = GetComponent<Text>();
    }
    public void SetMsg(string msg)
    {
        targetMsg = msg;
        EffectStart();
    }
    void EffectStart()
    {
        msgText.text = "";
        index = 0;
        

        //Start Animation
        interval = 0.1f / sec;
        Invoke("Effecting", interval);
    }
    void Effecting()
    {
        //End Animation
        if (msgText.text == targetMsg)
        {
            //EffectEnd();
            return;
        }

        msgText.text += targetMsg[index];
        index++;

        //Recursive
        Invoke("Effecting", interval);
    }
    void EffectEnd()
    {
        
    }

}

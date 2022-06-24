using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People 
{
    public string name;
    public int sizeOfBucket;
    public int rqWater;
    public string introDialogue;
    public string correctDialogue;
    public string wrongDialogue;
    public int indexNum;
    public GameObject human;
    
    public People(int index) {
        indexNum= index;

        if (index== 0) {
            name= "아주머니";
            sizeOfBucket= 10;
            rqWater= 5;

            introDialogue= "반만 줘~ (5)";
            correctDialogue= "고마우이~";
            wrongDialogue= "이걸 누구 코에 붙이누...";
        }
        else if (index== 1) {
            name= "꼬맹이";
            sizeOfBucket= 6;
            rqWater= 4;

            introDialogue= "네 번만 퍼 주세요(4)";
            correctDialogue= "감사합니다~";
            wrongDialogue= "네 번이라고 했잖아요~";
        }
        else if (index== 2) {
            name= "할아버지";
            sizeOfBucket= 4;
            rqWater= 4;

            introDialogue= "가득~...(4)";
            correctDialogue= "좀 더 주지...";
            wrongDialogue= "젊은 여자가... 쯧쯧";
        }
        else if (index== 3) {
            name= "아저씨";
            sizeOfBucket= 12;
            rqWater= 8;

            introDialogue= "많이 주시오 (8)";
            correctDialogue= "고맙소";
            wrongDialogue= "가물기는 했지...";
        }
    }
}


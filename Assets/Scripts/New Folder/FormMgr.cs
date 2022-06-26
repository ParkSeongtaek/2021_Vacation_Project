using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FormMgr : MonoBehaviour
{

    JsonMgr json;
    public string chapter;
    public string Name;
    public string Dialogue_think;
    public string backG;
    public string charimg;
    public string sound;

    int nameint;
    string namestring;
    int bgint;
    string dial;
    int idx;


    



    Dictionary<string, int> character;
    Dictionary<string, int> bg;
    Dictionary<string, int> soun;


    public List<FormClass> TransformList;
    FormClassWrapper formClassWrapper;
    
    void Start()
    {
        character = new Dictionary<string, int>();
        bg = new Dictionary<string, int>();
        soun = new Dictionary<string, int>();

        nameint = 101;
        namestring ="none";
        bgint = 100;
        dial = "" ;
        idx = 272;


        Name = "성준영";
        character.Add(Name, 10);
        Name = "손님";
        character.Add(Name, 8);
        Name = "주모";
        character.Add(Name, 50);
        Name = "호위무사";
        character.Add(Name, 8);
        Name = "앞집 아주머니";
        character.Add(Name, 90);
        Name = "어머니";
        character.Add(Name, 80);


        backG = "준영 집 내부";
        bg.Add(backG, 25);
        backG = "부엌";
        bg.Add(backG, 26);
        backG = "주막";
        bg.Add(backG, 5);
        backG = "준영집 마당";
        bg.Add(backG, 27);
        backG = "마당";
        bg.Add(backG, 27);
        backG = "산중턱";
        bg.Add(backG, 28);
        backG = "산입구in";
        bg.Add(backG, 29);
        backG = "산입구out";
        bg.Add(backG, 30);

        



        sound = "검은화면/새소리";
        soun.Add(sound, 1);
        sound = "회상-흑백 필터";
        soun.Add(sound, 2);
        sound = "검은화면";
        soun.Add(sound, 1);
        sound = "검은 화면";
        soun.Add(sound, 1);
        sound = "검은화면/강조연출?-글자슬로우?";
        soun.Add(sound, 1);
        sound = "검은화면/나무 찍는 소리";
        soun.Add(sound, 1);


        sound = "화면진동?-목소리 우렁참 표현";
        soun.Add(sound, 0);
        sound = "주변 거뭇거뭇(어둡다)";
        soun.Add(sound, 0);
        sound = "부스럭부스럭";
        soun.Add(sound, 0);
        sound = "심장소리 두근두근";
        soun.Add(sound, 0);
        sound = "(팝업일러?)";
        soun.Add(sound, 0);
        sound = "마당쓰는 소리";
        soun.Add(sound, 0);
        sound = "주저앉는 소리";
        soun.Add(sound, 0);
        sound = "화면 진동";
        soun.Add(sound, 0);
        sound = "회상-흑백";
        soun.Add(sound, 0);






        chapter = null;
        Name = null;
        Dialogue_think = null;
        backG = null;
        charimg = null;
        sound = null;

        json = new JsonMgr();

        formClassWrapper = json.ResourceDataLoad<FormClassWrapper>("ReForm");
        TransformList = formClassWrapper.TransformList;
        WriteTxt("Assets/Resources/Miju/Pro");   
    }
    
    void WriteTxt(string filePath)
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(Path.GetDirectoryName(filePath));

        if (!directoryInfo.Exists)
        {
            directoryInfo.Create();
        }

        FileStream fileStream
            = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write);

        StreamWriter writer = new StreamWriter(fileStream);
        //writer.WriteLine("Hello");

        Name = null;
        backG = null;


        /*
         * 
         *  nameint = 10;
        namestring ="";
        bgint = 5;
        dial = "" ;
        idx = 272;

         */

        try
        {
            for (int i = 0; i < TransformList.Count; i++)
            {
                //검은 화면 등 특수효과가 없을때 || 검은 화면 커멘드 1이 아니면
                if (TransformList[i].sound == "" || soun[TransformList[i].sound] != 1)
                {
                    //사람 이름이 있으면
                    if (TransformList[i].Name != "")
                    {
                        //사람이름 써주고
                        namestring = TransformList[i].Name;
                        nameint = character[TransformList[i].Name];
                    }
                    //사람 이름없으면
                    else
                    {
                        //그런데 대사가 있으면
                        if (TransformList[i].Dialogue_think != "")
                        {
                            //유지;
                        }
                        //대사가 없으면 (아마 해설)
                        else
                        {
                            nameint = 100;
                            namestring = "none";
                        }

                    }


                }
                //검은 화면 등 특수효과가 있으면 
                else
                {
                    //검은 화면 커멘드 1
                    if (soun[TransformList[i].sound] == 1)
                    {
                        nameint = 101;
                        namestring = "none";

                    }
                }
                //대사, 해설은 nameint 에서 구분해준다. text는 동일 위치에 기록
                dial = TransformList[i].sentence + TransformList[i].Dialogue_think;

                Debug.Log(i+"\t"+dial+idx);
                if (TransformList[i].backG != "")
                {
                    bgint = bg[TransformList[i].backG];
                }



                writer.WriteLine(nameint +"\t"+ namestring + "\t" + bgint + "\t" + dial + "\t" + idx); ;
                idx++;

            }


            writer.Close();
        }
        catch (KeyNotFoundException )
        {
            Debug.Log("???");
        }
    }

}

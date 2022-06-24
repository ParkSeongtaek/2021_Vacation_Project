using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewSpawn : MonoBehaviour
{
    [SerializeField] GameObject[] obj;
    List<int> usedNum;
    int SpawnObj;

    void Start()
    {
        usedNum = new List<int>();
        StartCoroutine(CreateRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateRoutine()
    {   
        while(usedNum.Count < 7)
        {
            SpawnPlay();
            float waitTime = Random.Range(1f, 2f); // 2f , 4f
            yield return new WaitForSeconds(waitTime);
            Debug.Log("create new GameObject");
        }
    }

    void SpawnPlay()
    {
        if (usedNum.Count == 6)
        {
            SpawnObj = 0;
        }
        else
        {
            //SpawnObj = Random.Range(1, 7); 빼도되지않나?
            while (usedNum.Count < 7)
            {
                if (usedNum.Contains(SpawnObj))
                {
                    SpawnObj = Random.Range(1, 7);
                }
                else
                {
                    break;
                }
            }
        }        

        //int caseNum = Random.Range(1, 4);
        Vector3 vec = new Vector3();
        // switch (caseNum)
        // {
        //     case 1:
        //         vec = new Vector3(0, 8, 0);
        //         break;
        //     case 2:
        //         vec = new Vector3(-4, 8, 0);
        //         break;
        //     case 3:
        //         vec = new Vector3(-8, 8, 0);
        //         break;

        // }
        vec = new Vector3(Random.Range(-8, 0), 8, 0);
        Instantiate(obj[SpawnObj], vec, Quaternion.identity);
        usedNum.Add(SpawnObj);
    }

    
}

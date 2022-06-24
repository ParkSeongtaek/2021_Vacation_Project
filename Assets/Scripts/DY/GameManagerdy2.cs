using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerdy2 : MonoBehaviour
{
    [SerializeField] 
    private GameObject snow1;
    // Start is called before the first frame update
    void Start()
    {
        CreateSnow();
        StartCoroutine(CreatesnowRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreatesnowRoutine()
    {   
        while(true)
        {
            CreateSnow();
            yield return new WaitForSeconds(1);
            Debug.Log("create new snowflake1");
        }
    }

    private void CreateSnow()
    {
        Vector3 pos = new Vector3(UnityEngine.Random.Range(25.0f, 85.0f), 10.0f, 0);
        pos.z = 0.0f;
        Instantiate(snow1, pos, Quaternion.identity);
    }
}

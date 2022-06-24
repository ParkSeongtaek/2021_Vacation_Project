using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerdy : MonoBehaviour
{
    [SerializeField] 
    private GameObject snow;
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
            yield return new WaitForSeconds(2);
            Debug.Log("create new snowflake");
        }
    }

    private void CreateSnow()
    {
        Vector3 pos = new Vector3(UnityEngine.Random.Range(-10.0f, 40.0f), 10.0f, 0);
        pos.z = 0.0f;
        Instantiate(snow, pos, Quaternion.identity);
    }
}

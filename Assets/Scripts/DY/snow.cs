using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snow : MonoBehaviour
{
    float snowStack, snowStack_mid, snowStack_easy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(this.gameObject);
            Debug.Log("Destroy by ground");
        }
        
        if(collision.gameObject.tag == "Player")
        {
            HealthGaugedy.health -= 5f;
            Destroy(this.gameObject);
            Debug.Log("Destroy by player");
        }

        snowStack = 0;
        if(collision.gameObject.tag == "shield_hard")
        {
            HealthGaugedy.health -= 1f;
            Destroy(this.gameObject);
            snowStack += 1;
            Debug.Log("Destroy by shield");
            if (snowStack == 3)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Debug.Log("Destroy your shield!");
            }
            
        }

        snowStack_mid = 0;
        if(collision.gameObject.tag == "shield_mid")
        {
            HealthGaugedy.health -= 1f;
            Destroy(this.gameObject);
            snowStack_mid += 1;
            Debug.Log("Destroy by shield");
            if (snowStack == 2)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Debug.Log("Destroy your shield!");
            }
        }

        snowStack_easy = 0;
        if(collision.gameObject.tag == "shield_easy")
        {
            HealthGaugedy.health -= 1f;
            Destroy(this.gameObject);
            snowStack_easy += 1;
            Debug.Log("Destroy by shield");
            if (snowStack == 1)
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
                Debug.Log("Destroy your shield!");
            }
        }
    }
}

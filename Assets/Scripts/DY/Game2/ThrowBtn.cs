using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ThrowBtn : MonoBehaviour
{
    [SerializeField] GameObject snare;
    public float startTime;
    public float btnTime;

    Vector2 startVec;
    Vector2 endVec;

    private void Start()
    {
        startVec = new Vector2 (-8.5f, -4.5f);
        endVec = new Vector2(8.5f, 4.5f);
    }
    private void Update()
    {

    }
    IEnumerator ThrowRoutine(float time)
    {
        Vector2 vec = (((endVec - startVec).normalized)*(1.92f + 5.76f*time) + startVec);

        float timer = 0;
        while(timer < 1)
        {
            snare.transform.position = Vector2.Lerp(startVec, endVec, timer);
            timer += Time.deltaTime;
            if (snare.transform.position.x >= vec.x)
            {
                break;
            }
            yield return null;
        }
    }
    IEnumerator ReturnRoutine()
    {

        yield return null;
    }

    public void btnDown()
    {
        startTime = Time.time;
    }
    public void btnUp()
    {
        btnTime = Time.time - startTime;
        StartCoroutine(ThrowRoutine(btnTime));
    }
}
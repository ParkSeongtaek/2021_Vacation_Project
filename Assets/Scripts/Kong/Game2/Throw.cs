using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Throw : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] GameObject snare;
    public float startTime;     public float btnTime;
    Vector2 startPos;
    private void Start()
    {
        startPos = new Vector2 (-8.5f, -4.5f);
    }
    private void Update()
    {

    }
    IEnumerator ThrowRoutine(float pressTime, Vector2 moveVec)
    {
        float timer = 0;
        while(timer < pressTime && timer < 1f)
        {
            snare.transform.position = new Vector2(snare.transform.position.x + moveVec.x , snare.transform.position.y + moveVec.y);
            timer += Time.deltaTime;
            
            yield return null;
        }
    }
    IEnumerator ReturnRoutine()
    {
        yield return null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Vector2 moveVec = new Vector2(eventData.position.x - startPos.x, eventData.position.y - startPos.y);
        StartCoroutine(ThrowRoutine(eventData.clickTime,moveVec));
    }
    
}
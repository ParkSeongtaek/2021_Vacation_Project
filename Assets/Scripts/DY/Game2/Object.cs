using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    public float speed;
    public Vector2 vec;

    void Start()
    {
        speed = Random.Range(0.5f, 1.5f); // 0.5~1.5 사이의 속도로 나오게 조정.
        rigid = GetComponent<Rigidbody2D>();
        vec = new Vector2(Random.Range(0.5f,1.5f) * speed, Random.Range(-2.0f,-1.0f) * speed);
    }

    private void FixedUpdate()
    {   
        rigid.velocity = vec;
    }

    void Update()
    {
        
    }
}

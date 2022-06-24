using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSet : MonoBehaviour
{
    public Transform Player;
    public Rigidbody2D rigidbody1;
    public SpriteRenderer renderer1;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody2D>();
        renderer1 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(MovePlayer.b)
        {
            renderer1.flipX = true;
        }
        if(MovePlayer.a)
        {
            renderer1.flipX = false;
        }

    }
    
}

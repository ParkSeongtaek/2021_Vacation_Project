using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public Transform Player;
    public float Speed;
    public Rigidbody2D rigidbody1;
    public Animator animator1;
    public SpriteRenderer renderer1;
    public static bool a, b;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody1 = GetComponent<Rigidbody2D>();
        animator1 = GetComponent<Animator>();
        renderer1 = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(a)
        {
            Player.position += Vector3.right*Speed*Time.deltaTime;
            HealthGaugedy.health -= 1f*Time.deltaTime;
            animator1.SetBool("state", false);
        }
        else
        {if(b)
            {
                Player.position += Vector3.left*Speed*Time.deltaTime;
                HealthGaugedy.health -= 1f*Time.deltaTime;
                animator1.SetBool("state", false);
            }
            else{animator1.SetBool("state", true);}
        }
        
    }
    public void Up()
    {
        a = false;
    }
    public void Down()
    {
        a = true;
    }
    public void BackUp()
    {
        b = false;
    }
    public void BackDown()
    {
        b = true;
    }
}

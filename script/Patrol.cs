using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Patrol : MonoBehaviour
{

    public float speed;
    public float distance;

    private bool movingLeft = true;
    public Transform groundDetection;
    public Transform wallDetection;
    
    public bool isPatrol = true;
    public LayerMask m_groundLayer;
    public float playerDistance = 5f;


    public float runspeed = 2.5f;

    public Animator animator;

    Transform player;
    Rigidbody2D rb;
    Boss boss;




    public Transform face;


    public float attackDistance = 4f;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        boss = GetComponent<Boss>();
        
         
    }

    // Update is called once per frame
    void Update()

       
        

    {


       
       if (transform.position.x > face.position.x)
        {
            boss.isFlipped = false;
           
        }
       else if (transform.position.x < face.position.x)
        {
            boss.isFlipped = true;
            

        }


            if (isPatrol == true)
        {
             Move();
           
        }
       else 
        { 

           
            moveToplayer();
            

        }
        //Debug.Log(isPatrol);

    }






    public void Move()

    {



        

        transform.Translate(Vector2.left * speed * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, distance, m_groundLayer);
        RaycastHit2D wallInfo = Physics2D.Raycast(wallDetection.position, Vector2.left, distance, m_groundLayer);



       


        if (groundInfo.collider == false|| wallInfo.collider==true)
        {
            if (movingLeft == true)
            {
                
                transform.Rotate(0f, 180f, 0f);
                boss.isFlipped = true;
                movingLeft = false;
                

            }
            else if(movingLeft == false)
            {

                
                transform.Rotate(0f, 180f, 0f);
                
                movingLeft = true;
                boss.isFlipped = false;


            }

           


        }

        
        if (Vector2.Distance(player.position, rb.position) <= playerDistance)
            {

            isPatrol = false;
            return;
        }
    }



    public void moveToplayer()
    {

       
        
           

            boss.LookAtPlayer();

            Vector2 target = new Vector2(player.position.x, rb.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);



            if (Vector2.Distance(player.position, rb.position) <= attackDistance)
            {
                animator.SetTrigger("bossattack");
            }
           
            if(Vector2.Distance(player.position, rb.position) > playerDistance)
            {
                isPatrol = true;
            }
           

        
    }
  }


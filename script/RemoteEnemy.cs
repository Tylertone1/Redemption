using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteEnemy : MonoBehaviour
{



   
    Transform player;
    Rigidbody2D rb;
    public Animator animator;
    Boss boss;
   
    public float attackDistance = 5f;

    public LayerMask m_playerLayer;






    bool m_Facingleft;

    public Transform playerDetection;


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



        moveToplayer();
        





    }










    public void moveToplayer()
    {





        boss.LookAtPlayer();


        RaycastHit2D playerInfo = Physics2D.Raycast(playerDetection.position, Vector2.left, attackDistance, m_playerLayer);
        RaycastHit2D playerInfo2 = Physics2D.Raycast(playerDetection.position, Vector2.right, attackDistance, m_playerLayer);

        if (playerInfo.collider == true|| playerInfo2.collider ==true)
        {
            
            animator.SetTrigger("bossattack");
           
        }

       



    }



   
}

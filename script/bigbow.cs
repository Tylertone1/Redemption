using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigbow : MonoBehaviour
{


    

   
     Animator animator;


    Transform player;
    Rigidbody2D rb;

    public float attackDistance = 20f;

    public bool open;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        open = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (open == true)
        {

            if (Vector2.Distance(player.position, rb.position) <= attackDistance)
            {
                animator.SetTrigger("attack");
            }
            if (Vector2.Distance(player.position, rb.position) > attackDistance)
            {
                animator.ResetTrigger("attack");
            }
        }
        if (open == false)
        {
            animator.ResetTrigger("attack");
        }
    }
}

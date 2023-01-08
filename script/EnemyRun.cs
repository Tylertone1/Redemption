using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRun : StateMachineBehaviour



   
{


    public float speed = 2.5f;

    Transform player;
    Rigidbody2D rb;
     Boss  boss;
    public float attackDistance = 4f;
    public AudioClip roar;
    Transform body;
    public float remoteDistance = 7f;

    // Start is called before the first frame update
    override public void OnStateEnter(Animator animator, AnimatorStateInfo state, int layerIndex)
    {
        body = animator.transform;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Boss>();
        AudioSource.PlayClipAtPoint(roar, body.position, 1);
    }


    override public void OnStateUpdate(Animator animator, AnimatorStateInfo state, int layerIndex)
    {

        boss.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, rb.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);



        if (Vector2.Distance(player.position, rb.position) <= attackDistance)
        {
            animator.SetTrigger("bossattack");
        }

        if (Vector2.Distance(player.position, rb.position) > attackDistance&& Vector2.Distance(player.position, rb.position) <= remoteDistance)
        {
            animator.SetTrigger("bossspattack");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo state, int layerIndex)
    {
        animator.ResetTrigger("bossattack");
        animator.ResetTrigger("bossspattack");
    }


}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stayboss : StateMachineBehaviour




{


    public float speed = 2.5f;

    Transform player;
    Rigidbody2D rb;
    Boss boss;
    public float attackDistance = 3f;
    public float remoteDistance = 10f;
    public float endDistance = 20f;
    public AudioClip roar;
    Transform body;

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

       



        if (Vector2.Distance(player.position, rb.position) <= attackDistance)
        {
            animator.SetTrigger("bossattack");
        }

        if (Vector2.Distance(player.position, rb.position) <= endDistance&& Vector2.Distance(player.position, rb.position)> remoteDistance)
        {
            animator.SetTrigger("bossremote");
        }
    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo state, int layerIndex)
    {
        animator.ResetTrigger("bossattack");
        animator.ResetTrigger("bossremote");
    }


}

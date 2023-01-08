using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class Playerattack : MonoBehaviour
{



    Animator m_anim;

    public Transform attackPoint;

    public float attackRange = 0.5f;


    public int m_damage = 30;

    public AudioClip hit;

    public AudioClip steps;

    public LayerMask enemyLayer;


    Transform enemy;
    



    // Start is called before the first frame update










    void Start()




    {
        enemy = GameObject.FindGameObjectWithTag("Enemy").transform;
      




        m_anim = GetComponent<Animator>();

    }

    // Update is called once per frame
 public void Attack()
    {



        Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemy)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.SendMessage("BeShot", m_damage, SendMessageOptions.DontRequireReceiver);
        }

        AudioSource.PlayClipAtPoint(hit, transform.position, 1);




    }


    public void step()
    {
        AudioSource.PlayClipAtPoint(steps, transform.position, 1);
    }

   



    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    private void OnTriggerExit2D(Collider2D collision)
    {



    }
}


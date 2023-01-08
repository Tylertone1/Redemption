using System.Collections;
using System.Collections.Generic;

using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class attack : MonoBehaviour
{

    protected Vector2 bulletSpeed = new Vector2(20, 0);
    public bool m_Facingright;

    public Animator m_anim;

    public Transform attackPoint;
    public Transform remoteattackPoint;
    public float attackRange = 0.5f;


    public  int m_damage = 20;
    public  int m_damage2 = 40;




    public LayerMask playerLayer;


    Transform player;
    Rigidbody2D rb;

    public AudioClip roar;

    // Start is called before the first frame update

    public GameObject pfb_bullet;


    public AudioClip remoteshooting;




    void Update()
    {
        if (transform.position.x > attackPoint.position.x)
        {
            m_Facingright = false;
        }
        else if (transform.position.x < attackPoint.position.x)
        {
            m_Facingright = true;
        }


    }



    void Start()




    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();




       // m_anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
   public void Attack()
    {

        
         
            Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

            foreach (Collider2D player in hitPlayer)
            {
                Debug.Log("We hit " + player.name);
                player.SendMessage("BeDamaged", m_damage, SendMessageOptions.DontRequireReceiver);
            }

        AudioSource.PlayClipAtPoint(roar, transform.position, 1);




    }




    public void rageAttack()
    {



        Collider2D[] hitPlayer = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayer);

        foreach (Collider2D player in hitPlayer)
        {
            Debug.Log("We hit again" + player.name);
            player.SendMessage("BeDamaged", m_damage2, SendMessageOptions.DontRequireReceiver);
        }

        AudioSource.PlayClipAtPoint(roar, transform.position, 1);




    }



    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;


        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }



    public void remoteAttack()
    {
        GameObject obj = Instantiate(pfb_bullet, remoteattackPoint.position, Quaternion.identity);
        


        AudioSource.PlayClipAtPoint(remoteshooting, transform.position, 1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

       

    }


    public void remoteAttack2()
    {
        GameObject obj = Instantiate(pfb_bullet, remoteattackPoint.position, Quaternion.identity);

        obj.GetComponent<Rigidbody2D>().velocity = m_Facingright ? bulletSpeed : -1 * bulletSpeed;

        AudioSource.PlayClipAtPoint(remoteshooting, transform.position, 1);
    }
}

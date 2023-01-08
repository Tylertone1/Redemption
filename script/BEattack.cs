using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BEattack : MonoBehaviour
{


    public GameObject pfb_bullet;
    protected Vector2 bulletSpeed = new Vector2(50, 0);
    


    public Animator animator;
    public GameObject body;
    public Transform attackPoint;
    public bool m_Facingright;
    public AudioClip shooting;


    // Start is called before the first frame update
    void Start()
    {
        
       
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > attackPoint.position.x)
        {
            m_Facingright = false;
        }
        else if(transform.position.x < attackPoint.position.x)
        {
            m_Facingright = true;
        } 


    }


    void Shooting()
    {
        //boss.isFlipped;
        
        GameObject obj = Instantiate(pfb_bullet, attackPoint.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = m_Facingright ? bulletSpeed : -1 * bulletSpeed;


        AudioSource.PlayClipAtPoint(shooting, transform.position, 1);


    }
}

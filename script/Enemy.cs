using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;


public class Enemy : MonoBehaviour
{

    Rigidbody2D m_enemy;
    CapsuleCollider2D m_colli;
    public int m_HP;
    public float speed = 10;
    public int MaxTurns = 3;
    private int turns = 0;
    public static int m_damage = 20;
    public static int m_damage2 = 100;

    public int exp;

    public LayerMask m_groundLayer;


   // public Healthbar healthBar;


   // public GameObject healthbar;




    public bool indamage = false;

    



    // Start is called before the first frame update

    void Awake()
    {
        
        m_enemy = GetComponent<Rigidbody2D>();
        m_colli = GetComponent<CapsuleCollider2D>();


    }


    void Start()
    {

        m_colli.isTrigger = false;
        Invoke("delayOpen", 0.5f);
        //healthBar.SetMaxHealth(m_HP);
    }

    // Update is called once per frame

    void delayOpen()
    {
        m_colli.isTrigger = true;

    }


    void Update()
    {




        

        

    }

    public AudioClip EnemyAudio;
    public AudioClip hited;


    public void BeShot(int damage)




    {



       // healthbar.SetActive(true);

        if (indamage)
            return;
        m_HP -= damage;
       


       // healthBar.SetHealth(m_HP);

        if (m_HP <= 500)
        {
            //GetComponent<Animator>().SetBool("isEnraged", true);
        }


        if (m_HP <= 0)
        {

            AudioSource.PlayClipAtPoint(EnemyAudio, transform.position, 1);
            
            Destroy(gameObject);
            Debug.Log("DEstroyed");
            turns++;
            print("success");
            







        }
    }
   


   // void OnTriggerEnter2D(Collider2D other)
   // {
        //if (other.gameObject.tag == "Player")
        //{
            //other.SendMessage("BeDamaged", m_damage, SendMessageOptions.DontRequireReceiver);
       // }

   // }

    int GetHP()
    {
        return m_HP;
    }





    
    //private void Flip()
    //{/
      // 
        //Vector3 scale = transform.localScale;
        //scale.x *= -1;
       // transform.localScale = scale;
   //}

    
    //void Awake()
    // {
    // exp = transform.GetComponent<EXP>().Myexp;
    //
    //}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bosshp : MonoBehaviour
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


     public HealthBar healthBar;


     public GameObject healthbar;




    public bool indamage = false;

    public Animator bossdoor;
    public bool start;

    public bool death;

    public GameObject gate;
    public Transform Gatepoint;
    // Start is called before the first frame update

    void Awake()
    {

        m_enemy = GetComponent<Rigidbody2D>();
        m_colli = GetComponent<CapsuleCollider2D>();


    }


    void Start()
    {
        death = false;
        start = false;
        m_colli.isTrigger = false;
        Invoke("delayOpen", 0.5f);
        healthBar.SetMaxHealth(m_HP);
    }

    // Update is called once per frame

    void delayOpen()
    {
        m_colli.isTrigger = true;

    }


    void Update()
    {


        if(death==true)
        {
           battle.Stop();
        }
       




    }

    public AudioClip EnemyAudio;
    public AudioSource battle;
    

    public void BeShot(int damage)




    {

        Debug.Log("hited");

         healthbar.SetActive(true);

        if (indamage)
            return;
        m_HP -= damage;



         healthBar.SetHealth(m_HP);
        start = true;
        if (m_HP <= 400)
        {
            GetComponent<Animator>().SetBool("isEnraged", true);
        }


        if (m_HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("death");
            AudioSource.PlayClipAtPoint(EnemyAudio, transform.position, 1);
           
            //Destroy(gameObject);
            Debug.Log("DEstroyed");
            turns++;
            print("success");
            bossdoor.SetTrigger("open");

            death = true;

            Instantiate(gate, Gatepoint.position, Quaternion.identity);



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

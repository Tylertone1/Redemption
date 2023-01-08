using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Security.Cryptography;

public class PlayerCtrl : MonoBehaviour





{


    public int m_HP = 100;
   
    public GameObject ui_GameOverImage;

   
    public AudioClip FailAudio;

    public HealthBar healthBar;


    public Transform attackPoint;

    public float dashTime;
    public float dashSpeed;
    float startDashTimer;
    public float coldTimer;
    public float remoteTimer;
    public bool getulremoteitem;

    public float recoverTime= 2.0f;
    public float presstime = 0;
    public float downtime;//recover

    private bool ready = false;//Key



    bool isDashing;
    public GameObject dashObject;

    public Playerattack attack;


    public GameObject effect;


    public GameObject hurteffect;

    bool m_isGrounded;
    bool m_isWalled;

    public LayerMask m_groundLayer;
    public float m_groundCheckDistance = 0.4f;

    public Transform m_headCheck;
    public Transform m_footCheck;
    public float m_wallCheckDistance = 1f;
   

    public Animator m_anim;
    Rigidbody2D m_body;

    public GameObject m_player;


    bool m_FacingRight = true;

    public float m_Speed = 8f;
    public float m_jumpForce = 20f;

    public float m_CanJumpTime = 0.2f;
    private float m_JumpTimer;
    private bool m_isJumping;

    private Vector2 m_vec;
    private float m_input_h;

    // 二段跳
    private int m_jumpTimes;



    public GameObject pfb_bullet;
    protected Vector2 bulletSpeed = new Vector2(20, 0);
    public AudioClip shooting;


    public AudioClip jump;
    public AudioClip getItem;
    public AudioClip swoosh;
    Vector2 m_NewForce;
    Vector2 m_NewForce2;//force
    void Awake()
    {
        //m_anim = gameObject.GetComponent<Animator>();
        m_body = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
       

        getulremoteitem = false;

        effect.SetActive(false);


        m_JumpTimer = 0f;
        m_isJumping = false;
        m_vec = new Vector2(0, m_jumpForce);
        m_jumpTimes = 0;
       


        // Vector3 vec = Vector3.zero;

        //vec.x = PlayerPrefs.GetFloat("CameraPosX", 0.5f);
        // vec.y = PlayerPrefs.GetFloat("CameraPosY", 0.5f);
        // vec.z = PlayerPrefs.GetFloat("CameraPosZ", -10);
        //  Camera.main.transform.position = vec;

        // vec.x = PlayerPrefs.GetFloat("PlayerPosX", -8.5f);
        // vec.y = PlayerPrefs.GetFloat("PlayerPosY", 7.5f);
        // vec.z = PlayerPrefs.GetFloat("PlayerPosZ", 0);
        // m_player.transform.position = vec;
        healthBar.SetMaxHealth(m_HP);

    }

    
    private void Update()
    {
        m_isGrounded = IsGrounded();

        coldTimer -= Time.deltaTime;
        remoteTimer -= Time.deltaTime;
        if (m_anim.GetBool("Ground") != m_isGrounded)
        {
            m_anim.SetBool("Ground", m_isGrounded);
        }

        
        if (m_HP <= 0)
        {
            Debug.Log("DEAD");
            // 玩家死亡
            Destroy(gameObject);
            hurteffect.SetActive(false);
            ui_GameOverImage.SetActive(true);
            AudioSource.PlayClipAtPoint(FailAudio, transform.position, 1);

        }
        else if (m_HP > 0 && m_HP <= 20)
        {
            hurteffect.SetActive(true);
        }
        else
        {
            hurteffect.SetActive(false);
        }
        #region 跳跃代码
        // 跳跃
        if (m_isJumping && Input.GetButton("Jump"))
        {
            if (m_JumpTimer <= m_CanJumpTime)
            {
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
                m_JumpTimer += Time.deltaTime;
            }
            else
            {
                m_isJumping = false;
            }
        }

        if(Input.GetButtonDown("Jump"))
        {
            if(m_isGrounded)
            {
                m_jumpTimes = 1;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }
            else if (m_jumpTimes == 1)
            {
                m_jumpTimes = 2;

                m_isJumping = true;
                m_JumpTimer = 0f;
                m_isGrounded = false;
                m_vec.x = m_body.velocity.x;
                m_body.velocity = m_vec;
            }
            AudioSource.PlayClipAtPoint(jump, transform.position, 1);
        }
        

        if (Input.GetButtonUp("Jump"))
        {
            m_isJumping = false;
        }

        m_anim.SetFloat("vSpeed", m_body.velocity.y);
        #endregion


        m_input_h = Input.GetAxisRaw("Horizontal");
        Move(m_input_h);






        if (Input.GetButtonDown("Fire1") )



        {

            m_anim.SetBool("attack", true);

           

        }

        if (Input.GetButtonUp("Fire1"))



        {

            m_anim.SetBool("attack", false);



        }



        if (Input.GetButtonDown("Fire2") && remoteTimer <= 0)



        {
            m_anim.SetBool("spattack", true);
            Shooting();
            //InvokeRepeating("Shooting", 0f, 0.5f);
            if(getulremoteitem == false)
            {
                remoteTimer = 3f;
            }
            

        }


        if (Input.GetButtonUp("Fire2"))
        {
            m_anim.SetBool("spattack", false);

            //CancelInvoke("Shooting");
        }


        if (Input.GetKeyDown(KeyCode.S)&&ready == false)
        {
            m_anim.SetBool("down", true);

            gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(0, gameObject.GetComponent<CapsuleCollider2D>().offset.y *0.2f);
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.5f, gameObject.GetComponent<CapsuleCollider2D>().size.y * 0.5f);

            m_isJumping = false;
            m_Speed = 1f;

            
            downtime = Time.time;
            presstime = downtime + recoverTime;
            ready = true;

           






        }

        if (Time.time >= presstime&&ready ==true)
        {
            Recover();

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            ready = false;
            m_anim.SetBool("down", false);
            gameObject.GetComponent<CapsuleCollider2D>().offset = new Vector2(0.2f, 1.365232f);
            gameObject.GetComponent<CapsuleCollider2D>().size = new Vector2(0.98f, 2.561774f);
            m_Speed =8f;
           
        }


        




    }

    public AudioClip recoverHP;
    public GameObject healeffect;

    void Recover()
    {
        
        
            m_HP += 30;
            healthBar.SetHealth(m_HP);
          ready = false;
        AudioSource.PlayClipAtPoint(recoverHP, transform.position, 1);
        healeffect.SetActive(true);
        StartCoroutine(LateCall2());
    }













    void Shooting()
    {
        m_anim.SetBool("spattack", true);
        GameObject obj = Instantiate(pfb_bullet, attackPoint.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = m_FacingRight ? bulletSpeed : -1 * bulletSpeed;



        AudioSource.PlayClipAtPoint(shooting, transform.position, 1);

    }








    private void Move(float h)
    {
        m_isWalled = IsWalled(m_FacingRight ? 1 : -1);

        if (m_FacingRight)
        {
            if (h < 0)
            {
                Flip();
            }
            else if (m_isWalled)
            {
                m_anim.SetBool("run", false);
                
                return;
            }
        }
        else
        {
            if (h > 0)
            {
                Flip();
            }
            else if (m_isWalled)
            {
                m_anim.SetBool("run", false);
                return;
            }
        }

       

        Vector2 v = m_body.velocity;
        v.x = h * m_Speed * 1;
        m_body.velocity = v;


        m_anim.SetBool("run", !(h == 0));
        


       
        

            if (!isDashing)
            {
                if (Input.GetKeyDown(KeyCode.LeftShift)&&coldTimer<=0)
                {

                    isDashing = true;
                    dashObject.SetActive(true);

                    startDashTimer = dashTime;
                coldTimer = 3f;
                AudioSource.PlayClipAtPoint(swoosh, transform.position, 1);
            }
            }
            else
            {
                startDashTimer -= Time.deltaTime;

                if (startDashTimer <= 0)
                {
                    isDashing = false;
                    dashObject.SetActive(false);
                    m_anim.SetBool("Charge", false);

                }
                else
                {
                    m_anim.SetBool("Charge", true);
                    if (h > 0)
                    {
                        m_body.velocity = transform.right * dashSpeed;
                    }
                    if (h < 0)
                    {
                        m_body.velocity = transform.right * dashSpeed * -1;
                    }
                   
                }

                
            }


           
        
        
    }

    private void Flip()
    {
        m_FacingRight = !m_FacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, m_groundCheckDistance, m_groundLayer);
        if (hit.collider != null)
        {
            return true;
        }
        return false;
    }

    private bool IsWalled(float dir)
    {
        RaycastHit2D hit1 = Physics2D.Raycast(m_headCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        RaycastHit2D hit2 = Physics2D.Raycast(m_footCheck.position, dir * Vector2.right, m_wallCheckDistance, m_groundLayer);
        if ((hit1.collider == null)&&(hit2.collider == null))
        {
            
            return false;
           
        }
        return true;
    }

    public AudioClip Hurt;
    
    private void BeDamaged(int damage)

    {
        Vector2 v = m_body.velocity;

        if (m_FacingRight == true)
        {
            v.x = 20* 1;
            m_body.velocity = v;
        }
        else if (m_FacingRight == false)
        {
            v.x = 20 * -1;
            m_body.velocity = v;
        }


            effect.SetActive(true);

        Debug.Log("get shot");
        m_HP -= damage;
       
        AudioSource.PlayClipAtPoint(Hurt, transform.position, 1);
        healthBar.SetHealth(m_HP);
       // 
        //{
            //m_NewForce = new Vector2(0f, 5f);
           // m_body.AddForce(m_NewForce, ForceMode2D.Impulse);
           // Debug.Log("right");
       // }
       // else if(m_FacingRight == false)
        //{
        //    m_NewForce2 = new Vector2(0f, 5f);
        //    m_body.AddForce(m_NewForce2, ForceMode2D.Impulse);
        //    Debug.Log("left");
       // }
        StartCoroutine(LateCall());

        

        //m_anim.SetTrigger("indamage");

        // m_HP -= 0;

        // m_anim.ResetTrigger("indamage");
    }


    public GameObject buff;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Atk")
        {
            attack.m_damage += 20;
            Debug.Log("current damage" + attack.m_damage);
            Destroy(other.gameObject);
            buff.SetActive(true);
            AudioSource.PlayClipAtPoint(getItem, transform.position, 1);

        }

        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Movingplatform")
        {
            this.transform.parent = col.transform;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Movingplatform")
        {
            this.transform.parent = null;
        }
    }

    IEnumerator LateCall()
    {
        Debug.Log("close");
        yield return new WaitForSeconds(0.1f);

        effect.SetActive(false);
        //Do Function here...
    }

    IEnumerator LateCall2()
    {
        Debug.Log("close");
        yield return new WaitForSeconds(1.5f);

        healeffect.SetActive(false);
        //Do Function here...
    }
}

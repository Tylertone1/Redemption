using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Switch : MonoBehaviour
{
    public GameObject Player;
    public Animator m_anim;
    public Animator m_anim2;
    public AudioClip Switchon;
    // Start is called before the first frame update
    void Start()
    {
       Player = GameObject.FindGameObjectWithTag("Player");

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("in");

           
                m_anim.SetBool("on", true);
                m_anim2.SetBool("Open", true);
            AudioSource.PlayClipAtPoint(Switchon, transform.position, 1);
        }
        if(other.gameObject.tag == "bullet")
        {
            m_anim.SetBool("on", true);
            m_anim2.SetBool("Open", true);
            AudioSource.PlayClipAtPoint(Switchon, transform.position, 1);
        }

    }
}

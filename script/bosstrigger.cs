using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosstrigger : MonoBehaviour
{


    public Animator m_anim;
    public Animator dooranim;// Start is called before the first frame update
    void Start()
    {
        
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


            m_anim.SetBool("in", true);

            dooranim.SetTrigger("close");
           


        }


    }

}

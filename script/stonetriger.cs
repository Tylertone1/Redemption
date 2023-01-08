using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stonetriger : MonoBehaviour
{


    public Animator m_anim;

    public AudioClip stone;

     bool played;

   
    // Start is called before the first frame update
    void Start()
    {
        played = false;
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


            m_anim.SetBool("move", true);


            if (played == false) {
                AudioSource.PlayClipAtPoint(stone, transform.position, 1);
                played = true;
                    }
            

        }
        

    }

}

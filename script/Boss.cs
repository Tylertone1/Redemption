using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class Boss : MonoBehaviour
{
   public Transform player;
    //Rigidbody2D rb;
    public bool isFlipped= false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    public void LookAtPlayer()
    {
        //rb = GetComponent<Rigidbody2D>();
        //if (rb.)




       
          


        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;

        

        if (transform.position.x>player.position.x && isFlipped)
        {
            //transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
            
            
        }
        else if(transform.position.x< player.position.x && !isFlipped)
        {
           // transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;

            
        }
       

    }


    
}

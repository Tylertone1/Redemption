using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletfaceplayer : MonoBehaviour
{
    // Start is called before the first frame update


    public Transform player;
    //Rigidbody2D rb;
    public bool isFlipped;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        LookAtPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void LookAtPlayer()
    {
        //rb = GetComponent<Rigidbody2D>();
        //if (rb.)








        Vector3 flipped = transform.localScale;
        flipped.x *= -1f;



        if (transform.position.x > player.position.x && isFlipped)
        {
            //transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;

        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            // transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;


        }


    }
}

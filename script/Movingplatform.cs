using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movingplatform : MonoBehaviour
{
   public  float dirX, moveSpeed = 3f;
    bool moveRight = true;
    public bool move;
    public Transform left;
    public Transform right;
    //Rigidbody2D rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (move == true)

        {
        if (transform.position.x > right.position.x)


            moveRight = false;
        if (transform.position.x<left.position.x)
            
                
                moveRight = true;
            
           
            

            if (moveRight)
            
               
                transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y );
                
            
            else
            
                
                transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y );
               
            
            
           
        }
    }
}

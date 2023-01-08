using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterbehavior : MonoBehaviour
{
    public Rigidbody2D player;
    public GameObject water;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("get");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("get");
            player.gravityScale = 0.5f;
            Instantiate(water, player.position, Quaternion.identity);

            
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            player.gravityScale = 3;
        }
    }

   
}

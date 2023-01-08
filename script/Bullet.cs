using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;


using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Globalization;


public class Bullet : MonoBehaviour
{
    public int bullet_damage = 15;
    public Bullet data;
    public GameObject win;

    public int bullet_damage2 = 20;//enemy bullet

    Rigidbody2D rb;
    
 







    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {

            collision.SendMessage("BeShot", bullet_damage, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);
        }
       
        else if (collision.gameObject.tag == "Player")
        {
            
            collision.SendMessage("BeDamaged", bullet_damage2, SendMessageOptions.DontRequireReceiver);
            Destroy(gameObject);

        }

        
    }

   

    // Start is called before the first frame update
    void Start()
    {

       
       
        
    }

    // Update is called once per frame
    void Update()
    {
        win = GameObject.FindWithTag("Respawn");

        
        winover();

        


    }

    public void winover()
    {
        var asshole = win;
        
        if(asshole != null)
        {
            bullet_damage += 100;
        }
    }
    
}

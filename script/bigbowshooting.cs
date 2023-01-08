using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class bigbowshooting : MonoBehaviour
{
    public GameObject pfb_bullet;
    protected Vector2 bulletSpeed = new Vector2(50, 0);
    float fireRate;
    float nextFire;
    public Transform attackPoint;
    public Transform attackPoint2;
    public Transform attackPoint3;
    public AudioClip shooting;


    // Start is called before the first frame update
    void Start()
    {
        


    }

    // Update is called once per frame
    void Update()
    {
       


    }


    void Shooting()
    {
        //boss.isFlipped;
       
        
             
            GameObject obj = Instantiate(pfb_bullet, attackPoint.position, Quaternion.identity);
        GameObject obj2 = Instantiate(pfb_bullet, attackPoint2.position, Quaternion.identity);
        GameObject obj3 = Instantiate(pfb_bullet, attackPoint3.position, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = bulletSpeed*-1;
        obj2.GetComponent<Rigidbody2D>().velocity = bulletSpeed * -1;
        obj3.GetComponent<Rigidbody2D>().velocity = bulletSpeed * -1;
        AudioSource.PlayClipAtPoint(shooting, transform.position, 1);
        

    }
}

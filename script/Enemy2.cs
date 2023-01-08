using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{


    Material material;
    public GameObject mainbody;
    public int m_HP;
    public int m_damage = 10;

    bool isDissolving = false;
    float fade = 1f;

    bool dissolved = false;



    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_HP <= 0)
        {

            isDissolving = true;








        }
        if (isDissolving)
        {
            fade -= Time.deltaTime;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;

                Destroy(mainbody);
            }

            material.SetFloat("_Fade", fade);

        }
        
    }


    public GameObject ui_congrats;

    void BeShot(int damage)
    {
        m_HP -= damage;
        Debug.Log(m_HP);
       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.SendMessage("BeDamaged", m_damage, SendMessageOptions.DontRequireReceiver);
        }
    }

}

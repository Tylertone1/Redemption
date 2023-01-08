using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class traptrigger : MonoBehaviour
{
    public GameObject element;
    Rigidbody2D ex;
    void OnTriggerEnter2D(Collider2D other)
    {

        ex.constraints = RigidbodyConstraints2D.None;


    }
    // Start is called before the first frame update
    void Start()
    {

        ex = element.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

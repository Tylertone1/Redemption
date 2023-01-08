using System;
using UnityEngine;


public class faceplayer: MonoBehaviour
{
    public Transform target;


    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (target != null)
        {
            transform.LookAt(target);
        }
    }

}

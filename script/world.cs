using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class world : levelloader1
{
    // Start is called before the first frame update

    public Transform player;
    public Transform pos;
    public string previous;
     public override void Start()
    {
        base.Start();
        
        if (prevScene == previous)
        {
            player.position = pos.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

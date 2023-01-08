using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enterswitch : MonoBehaviour
{

    [SerializeField]
    private string sceneName;
    levelloader1 levelloader;
    
    // Start is called before the first frame update
    void Start()
    {
        levelloader = FindObjectOfType<levelloader1>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            levelloader.SwitchScene(sceneName);
        }
    }
}

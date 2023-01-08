
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private bool playerDetected;
    public Transform doorPos;
    public float width;
    public float height;

    public LayerMask whatIsPlayer;




    [SerializeField]
    private string sceneName;
    levelloader1 levelloader;

    public GameObject pressE;










    // Start is called before the first frame update


    private void Start()
    {
        levelloader = FindObjectOfType<levelloader1>();
       //pressE = GameObject.FindWithTag("pressE");

    }

    // Update is called once per frame
    public void Update()
    {
        playerDetected = Physics2D.OverlapBox(doorPos.position, new Vector2(width, height), 0, whatIsPlayer);

        if(playerDetected == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                levelloader.SwitchScene(sceneName);
            }



        }
       }


    private void OndrawGizmosSelected()
    {
       Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(doorPos.position, new Vector3(width,height, 2));
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("get");
            pressE.SetActive(true);
        }
    }
     void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            pressE.SetActive(false);
        }
    }
}

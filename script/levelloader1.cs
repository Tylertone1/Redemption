using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelloader1 : MonoBehaviour
{


    public Animator transition;
    // Start is called before the first frame update
    public float transitionTime = 1f;
   
    // Update is called once per frame
    
    
    public void LoadNextLevel()

    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        
    }


    

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }



    public static string prevScene;
    public static string currentScene;

    public virtual void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }


    public void SwitchScene(string sceneName)
    {
        prevScene = currentScene;
        transition.ResetTrigger("start");
        SceneManager.LoadScene(sceneName);
       

    }
}

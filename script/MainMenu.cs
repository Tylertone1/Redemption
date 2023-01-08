using System.Collections;
using System.Collections.Generic;


using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;



public class MainMenu : MonoBehaviour
{


    public Animator transition;
    // Start is called before the first frame update
    public float transitionTime = 1f;


    public AudioMixer audioMixer;
    public TMPro.TMP_Dropdown resolutionDropdown;
     
    Resolution[] resolutions;

    // Start is called before the first frame update

        void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();


        int currentResolutionIdex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIdex = i;
            }
               
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIdex;
        resolutionDropdown.RefreshShownValue();
    }


    public void SetResolution (int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }



    
   public void PlayGame()
    {

       
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
    }  

    public void QuitGame()
    {

        Debug.Log("QUIT!");
        Application.Quit();
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume",volume);
    }

    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

}

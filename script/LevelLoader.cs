﻿using System.Collections;

using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;




public class LevelLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;


    public void LoadLevel(int sceneIndex) 
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }




    IEnumerator LoadAsynchronously(int sceneIndex)


    {

        Time.timeScale = 1f;
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {

            float progress = Mathf.Clamp01(operation.progress / .9f);
            slider.value = progress;
            Debug.Log(operation.progress);


            yield return null;
        }
    }
}

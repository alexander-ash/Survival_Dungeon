using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class NextLevel : MonoBehaviour
{
    int numberOfScenes;

    void Start()
    {
        numberOfScenes = SceneManager.sceneCountInBuildSettings;        
    }


    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSecondsRealtime(0f);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneindex = currentSceneIndex + 1;
        if (numberOfScenes > nextSceneindex)
        {
            SceneManager.LoadScene(nextSceneindex);
            Debug.Log("NEXT");            
        }
        else
        {
            SceneManager.LoadScene(0);
            Debug.Log("Win！");
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(LoadNextLevel());
    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        SceneManager.LoadScene(0);
//    }
}

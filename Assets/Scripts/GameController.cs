using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] int lives = 3;
    [SerializeField] int scoreCount = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI gameText;
    
    
    private void Awake()
    {
        
        int numOfGameSessions = FindObjectsOfType<GameController>().Length;
        if (numOfGameSessions > 1)
        {
            Destroy(gameObject); // destroy all newly created instances of GameSession 
                                 // to keep data saved between lvls and death
        }  
        else
        {
            DontDestroyOnLoad(gameObject); // make current instance as a main and avoid destroing            
        }        
    }

    void Start()
    {
        gameText.text = "";
        scoreText.text = scoreCount.ToString();
        
    }

    private void Update()
    {
       FindObjectOfType<LoosingHeart>().ShowLiveNumber(lives); 
    }
    //Actions when player is dead

    public void ProceedDeath() 
    {
       if (lives > 1)
       {
            Invoke("MinusLife", 1.5f);   
            
       }
       else
       {
            gameText.text = "Game Over";
            Invoke("ResetGame", 6f);            
       }
    }

    public void MinusLife()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        lives--;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void AddCoins(int value)
    {
        scoreCount += value;
        scoreText.text = scoreCount.ToString();
    }
    //Destroy game session to refresh the game
    private void ResetGame()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
}

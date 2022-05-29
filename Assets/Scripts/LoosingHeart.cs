using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoosingHeart : MonoBehaviour
{
    [SerializeField] GameObject[] hearts = new GameObject[3];
    int initialLives, livesLeft;

    void Start()
    {
      initialLives = livesLeft = 3; // max num of Hearts       
    }

    void Update()
    {
        //Debug.Log($"IL:{initialLives}, lives:{livesLeft}");
        for (int i = livesLeft; i < initialLives; i++)
        {
            hearts[i].SetActive(false);
        }
    }
    public void ShowLiveNumber(int value)
    {
        livesLeft = value;
    }
}

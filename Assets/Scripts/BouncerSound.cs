using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerSound : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        FindObjectOfType<AudioManager>().PlaySound("BouncerSound");
    }   
    
}    

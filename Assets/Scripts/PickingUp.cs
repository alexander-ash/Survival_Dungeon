using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickingUp : MonoBehaviour
{
    /// <summary>
    /// For pucking up interactible Objects
    /// </summary>
        
    // defaul coin value
    [SerializeField] int coinValue = 10;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (gameObject.tag == "Coin")
            {
                FindObjectOfType<GameController>().AddCoins(coinValue);
            }
            if (gameObject.tag == "Star")
            {
                FindObjectOfType<BlocksAndStars>().OpenTheDoor();
            }
            FindObjectOfType<AudioManager>().PlaySound("CoinSound");
            gameObject.SetActive(false); // to avoid false triggering
            Destroy(gameObject);
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Rigidbody2D enemyRigidbody2D;
    [SerializeField] float movingSpeed = 1;

    void Start()
    {
        enemyRigidbody2D = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        enemyRigidbody2D.velocity = new Vector2(movingSpeed, 0f);
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        movingSpeed = -movingSpeed;
        Flipper();
    }
    private void Flipper()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(enemyRigidbody2D.velocity.x)), 1f);
    }




}

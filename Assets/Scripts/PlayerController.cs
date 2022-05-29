using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // set basic player characteristics 
    Vector2 moveInput;
    Rigidbody2D rigidbody2D;
    Animator anime;
    CapsuleCollider2D playerCollider2D;
    BoxCollider2D touchFeet;
    [SerializeField] AudioManager audioManager;

    [SerializeField] float runningSpeed = 10;
    [SerializeField] float jumpSpeed = 3;
    float defaultGravityScale;
    bool isDead = false;
    bool isPaused = false;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        playerCollider2D = GetComponent<CapsuleCollider2D>();
        touchFeet = GetComponent<BoxCollider2D>();
        defaultGravityScale = rigidbody2D.gravityScale;
    }

    void Update()
    {
        if (isDead) { return; }        
        if (isPaused) { return; }
        JumpingAnimation();
        Running();
        Flipper();
        Climbing();
        Death();      
    }
     

    private void JumpingAnimation()
    {      
            anime.SetBool("IsJumping", (!playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))
            &&                      !playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Stairs")) 
            &&                      !playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Deadly"))));
            
    }

    void OnJump(InputValue value)
    {
        if (isDead) 
                    { return; }
        if (isPaused) 
                    { return; }
        if (!touchFeet.IsTouchingLayers(LayerMask.GetMask("Ground"))) // make Jump only from Ground
                    { return; }
        if (value.isPressed)
        {
            rigidbody2D.velocity += new Vector2(0f, jumpSpeed);
            audioManager.PlaySound("JumpSound");
        }
    }

    private void Flipper()
    {
        bool playerAreMoving = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon; //Mathf.Epsilon awoid false triggering
        if (playerAreMoving)
        {
            transform.localScale = new Vector2(Mathf.Sign(rigidbody2D.velocity.x), 1f);
            
        }
    }

    private void Running()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runningSpeed, rigidbody2D.velocity.y);
        rigidbody2D.velocity = playerVelocity;       
           anime.SetBool("IsRunning", (Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon));
           //audioManager.PlayAndStopSound("ClimbingSound", (Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon));
        
        
    }
    private void Climbing()
    {
        if (playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Stairs")))
        {
            Vector2 playerVelocity = new Vector2(rigidbody2D.velocity.x, moveInput.y * runningSpeed);
            rigidbody2D.velocity = playerVelocity;
            rigidbody2D.gravityScale = 0; // avoid gliding down
                anime.SetBool("IsClimbing", Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon);
                //audioManager.PlayAndStopSound("ClimbingSound", Mathf.Abs(rigidbody2D.velocity.y) > Mathf.Epsilon);
           
        }
        else
        {
            rigidbody2D.gravityScale = defaultGravityScale;
            anime.SetBool("IsClimbing", false);
        }
    }   

    
    void OnMove(InputValue value)
    {
        if (isDead) { return; }
        if (isPaused) { return; };
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    private void Death()
    {
        if (playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Enemies")) ||
            playerCollider2D.IsTouchingLayers(LayerMask.GetMask("Deadly")))
        {
            isDead = true;
            anime.SetBool("isDead", true);
            Invoke("DisablePlayer", 0.7f);
            Destroy(rigidbody2D);
            FindObjectOfType<GameController>().ProceedDeath();
            audioManager.PlaySound("DeathSound");
        }
    }
    private void DisablePlayer()
    {
        this.gameObject.SetActive(false);
    }
    void OnPause(InputValue value) 
    {
        if (value.isPressed)
        {
            isPaused = !isPaused;
        }
    }
    public void doYouOnPause(bool value)
    {
        isPaused = value;
    }
}

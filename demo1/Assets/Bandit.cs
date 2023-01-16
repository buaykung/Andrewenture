using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bandit : MonoBehaviour
{
    //public fields
    public float speed = 1;

    //private fields
    
    Rigidbody2D rb;
    Animator animator;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;

    const float groundCheckRadius = 0.2f;
    [SerializeField] bool isGrounded;
    [SerializeField] float jumpPower = 500;
    [SerializeField] int totalJumps;
    int availableJumps;
    float horizontalValue;
    bool facingRight = true;
    bool jump;
    bool mutipleJumps;
    
    void Awake() {

        availableJumps = totalJumps;
        Debug.Log(availableJumps);
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    void Update(){

        animator.SetFloat("yVelocity",rb.velocity.y);
        horizontalValue = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump"))
            Jump();
        
    }

    void FixedUpdate(){
        GroundCheck();
        Move(horizontalValue);
    }

    void GroundCheck(){
        
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position,groundCheckRadius, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
            if(!wasGrounded)
            {
                availableJumps = totalJumps;
                mutipleJumps = false;
                Debug.Log(wasGrounded);
            }
                
        }
        animator.SetBool("Jump",!isGrounded);
    }

    void Jump(){
        if(isGrounded)
        {
            mutipleJumps = true;
            availableJumps--;
            rb.velocity = Vector2.up * jumpPower;
            animator.SetBool("Jump",true);

        }else{
            if(mutipleJumps && availableJumps > 0)
            {
                availableJumps--;
                rb.velocity = Vector2.up * jumpPower;
                animator.SetBool("Jump",true);
            }
        }
    }

    void Move(float dir){


        //set value of x using dir and speed
        float xVal = dir * 100 * speed * Time.deltaTime;
        //Creat vec2 for the velocity
        Vector2 targeVelocity = new Vector2(xVal,rb.velocity.y);
        //Set the player's velocity
        rb.velocity = targeVelocity;

        if(facingRight && dir < 0){
            transform.localScale = new Vector3(-5,5,5);
            facingRight = false;
        }
        if(!facingRight && dir > 0){
            transform.localScale = new Vector3(5,5,5);
            facingRight = true;
        }
        //0 idel, 8 running
        //Set the velocity according to the value x
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
    }


}    
    

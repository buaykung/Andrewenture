using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 40f;
    public float jumpRate = 0.5f;
    public float nextJumpPress = 0.0f;
    float horizontalMove = 0f;
    
    bool jump = false;
    bool crouch = false;

    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed",Mathf.Abs(horizontalMove));

        if(Input.GetButtonDown("Jump"))
        {
            animator.SetBool("Jump",true);
            jump = true;
            
        }

        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding(){
        animator.SetBool("Jump",false);
    }

    void FixedUpdate(){

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        
        jump = false;
        
    }
}

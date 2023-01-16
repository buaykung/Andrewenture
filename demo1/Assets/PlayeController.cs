using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayeController : MonoBehaviour
{
    public float speed = 20f;
    public float jumpSpeed = 9f;
    public float maxSpeed = 200f;
    public float JumpPower = 20f;
    public bool grounded;
    public float jumpRate = 0.5f;
    public float nextJumpPress = 0.0f;

    private Rigidbody2D rigidBody2D;
    private Physics2D physics2D;
    Animator animator;
    public int healthbar = 100;
    // public Text healthText;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody2D = this.gameObject.GetComponent<Rigidbody2D>();
        animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("Grounded",true);
        animator.SetFloat("Speed",Mathf.Abs(Input.GetAxis("Horizontal")));
        if(Input.GetAxis("Horizontal") < -0.1f ){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,180);

        }else if(Input.GetAxis("Horizontal") > 0.1f ){
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0,0);

        }

        if(Input.GetButtonDown("Jump") && Time.time > nextJumpPress){
            animator.SetBool("Jump",true);
            nextJumpPress = Time.time + jumpRate;
            rigidBody2D.AddForce(jumpSpeed*(Vector2.up * JumpPower));

        }else{
            animator.SetBool("Jump",false);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float runSpeed = 10f;

    [SerializeField]
    private float jumpSpeed = 20f;

    [SerializeField]
    private Rigidbody2D myBody;

    [SerializeField]
    private BoxCollider2D myCollider;

    [SerializeField]
    private SpriteRenderer mySR;

    [SerializeField]
    private Animator myAnimator;

    private float movementX;
    private string RUN_ANIMATION = "Run";
    private string JUMP_ANIMATION = "Jump";

    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerAnimation();
        PlayerJump();   
    }

    private void PlayerMovement()
    {
        movementX = Input.GetAxis("Horizontal");
        transform.position=transform.position+new Vector3(movementX,0,0)*runSpeed*Time.deltaTime;
    }

    private void PlayerAnimation()
    {
        if(movementX > 0) 
        {
            myAnimator.SetBool(RUN_ANIMATION, true);
            mySR.flipX = false;
        }

        else if(movementX < 0) 
        {
            myAnimator.SetBool(RUN_ANIMATION, true);
            mySR.flipX = true;
        }

        else
        {
            myAnimator.SetBool(RUN_ANIMATION,false);
        }
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
           myBody.AddForce(new Vector2 (0f,jumpSpeed), ForceMode2D.Impulse);
           PlayerJumpAnimation();
           isGrounded = false;  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            myAnimator.SetBool(JUMP_ANIMATION, false);
        }
    }

    private void PlayerJumpAnimation()
    {
        if (movementX > 0)
        {
            myAnimator.SetBool(JUMP_ANIMATION, true);
            mySR.flipX = false;
        }

        else if (movementX < 0)
        {
            myAnimator.SetBool(JUMP_ANIMATION, true);
            mySR.flipX = true;
        }

        else
        {
            myAnimator.SetBool(JUMP_ANIMATION, true);
        }
    }
}

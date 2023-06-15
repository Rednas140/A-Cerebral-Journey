using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rb;
    public Animator animator;

    public static float speed = 3f;
    public float jump;

    private bool isJumping;

    private float inputHorizontal;
    private bool inputJump;
    private bool facingRight = true;
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() 
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputJump = Input.GetButtonDown("Jump");

        animator.SetFloat("PlayerSpeed", Mathf.Abs(inputHorizontal));

        canMove = Dialogue.isTalking;

        if (inputJump && isJumping == false && !canMove)
        {
            rb.AddForce(new Vector2(rb.velocity.x, jump));
        }
    }

    void FixedUpdate() 
    {

        if (inputHorizontal != 0 && !canMove)
        {
            rb.velocity = new Vector2(speed * inputHorizontal, rb.velocity.y);
        }

        if (inputHorizontal > 0 && !facingRight) 
        {
            Flip();
        }

        else if (inputHorizontal < 0 && facingRight)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform")) 
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}

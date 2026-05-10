using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

   public float baseBPM = 140f;        
    public float currentBPM = 140f;     
    public float unitsPerBeat = 3f;      
	public float speed;
    public float jumpForce = 8.0f;
    public Rigidbody2D rb;
    public Transform groundCheckBottom;
    public Transform groundCheckTop;
    public LayerMask groundLayer;
    public AudioSource music;
    public bool isMoving = false;
    public bool isGrounded;
    private bool isHit;
    public Animator animator;
    
    void Start()
    {
        speed =  (currentBPM / 60f) * unitsPerBeat;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
           transform.Translate(new Vector2(x:speed * Time.deltaTime, y:0)); 
           isGrounded = Physics2D.OverlapCircle(groundCheckBottom.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheckTop.position, 0.1f, groundLayer);
            jump();
       } 
        animator.SetBool("is_moving", isMoving);
        animator.SetBool("player_grounded", isGrounded);

    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

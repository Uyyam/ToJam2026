using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

	public float speed = 8.0f;
    public float jumpForce = 8.0f;
    public Rigidbody2D rb;
    public Transform groundCheckBottom;
    public Transform groundCheckTop;
    public LayerMask groundLayer;
    private bool isGrounded;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckBottom.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheckTop.position, 0.1f, groundLayer);
        transform.Translate(new Vector2(x:speed * Time.deltaTime, y:0));
        jump();
        print(isGrounded);
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{

   public float baseBPM = 120f;        
    public float currentBPM = 120f;     
    public float unitsPerBeat = 4f;      
	public float speed;
    public float jumpForce = 8.0f;
    public Rigidbody2D rb;
    public Transform groundCheckBottom;
    public Transform groundCheckTop;
    public LayerMask groundLayer;
    public AudioSource music;
    private bool isGrounded;
    private bool isHit;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        speed =  (currentBPM / 60f) * unitsPerBeat;
        isGrounded = Physics2D.OverlapCircle(groundCheckBottom.position, 0.1f, groundLayer) || Physics2D.OverlapCircle(groundCheckTop.position, 0.1f, groundLayer);
       transform.Translate(new Vector2(x:speed * Time.deltaTime, y:0));
       Debug.Log("TIME: " + Time.deltaTime * speed);
              Debug.Log("AUDIO TIME: " + music.time * 0.008f);
        jump();
    }

    private void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gravityButton : MonoBehaviour
{
    public playerMove playerMoveScript;
    public Rigidbody2D playerRb;
    public Transform graph;
    public Scrollbar gravityScrollbar;
    public float gravityInverted = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeGravity()
    {   

        gravityInverted = gravityInverted * -1.0f;
        playerRb.gravityScale = -playerRb.gravityScale;
        playerMoveScript.jumpForce = -playerMoveScript.jumpForce;
        graph.Rotate(0, 0, 180);
    }
}

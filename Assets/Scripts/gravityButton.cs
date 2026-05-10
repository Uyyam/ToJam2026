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

    private Color baseColor;
    private Color toggledColor;

    public Animator animator;
    private bool gravityIsActive = true;

    private Button button;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        baseColor = button.colors.normalColor;
        toggledColor = button.colors.selectedColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeGravity()
    {

        gravityIsActive = !gravityIsActive; // toggle gravity bool for animation purposes
        ColorBlock cb = button.colors; // make 
        
        if (button.colors.normalColor == baseColor)
        {
            cb.normalColor = toggledColor;
        }
        else if (button.colors.normalColor == toggledColor)
        {
            cb.normalColor = baseColor;
        }
        button.colors = cb;

        animator.SetTrigger(gravityIsActive ? "DisableGrav" : "ChangeGrav");
        
        gravityInverted = gravityInverted * -1.0f;
        playerRb.gravityScale = -playerRb.gravityScale;
        playerMoveScript.jumpForce = -playerMoveScript.jumpForce;
       // graph.Rotate(0, 0, 180);
    }
}

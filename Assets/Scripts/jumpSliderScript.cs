using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jumpSliderScript : MonoBehaviour
{

	public playerMove playerScript;
    public gravityButton gravityButtonScript;
	public Transform player;
	public Slider jumpSlider;
	public Slider jumpBar;
	public float minTarget = 5;
	public float maxTarget = 30;
	
	public float playerStartY;
    private float jumpDist;
    // Start is called before the first frame update
    void Start()
    {
    	playerStartY = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
    	if(playerScript.isGrounded){
    	playerStartY = player.position.y;
    	jumpBar.value=0;
    	}
    	if(!playerScript.isGrounded){
        jumpDist = Mathf.Abs(player.position.y - playerStartY);
    	jumpBar.value= Mathf.Lerp(0, 1, Mathf.InverseLerp(0, 7, jumpDist));
    	print(jumpDist);
    	}
    }
    
    public void changeJumpForce(){
    float mappedValue = Mathf.Lerp(minTarget, maxTarget, Mathf.InverseLerp(0, 1, jumpSlider.value));
    playerScript.jumpForce = mappedValue * gravityButtonScript.gravityInverted;
    }
}

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
	public float minTarget = 4;
	public float maxTarget = 16;
	
	private float playerStartY;
    private float jumpDist;
    // Start is called before the first frame update
    void Start()
    {
    	playerStartY = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        jumpDist = Mathf.Abs(player.position.y - playerStartY);
    	jumpBar.value= Mathf.Lerp(0, 1, Mathf.InverseLerp(0, 4, jumpDist));
    }
    
    public void changeJumpForce(){
    float mappedValue = Mathf.Lerp(minTarget, maxTarget, Mathf.InverseLerp(0, 1, jumpSlider.value));
    playerScript.jumpForce = mappedValue * gravityButtonScript.gravityInverted;
    }
}

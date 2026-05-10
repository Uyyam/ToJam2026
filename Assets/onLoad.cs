using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class onLoad : MonoBehaviour
{
	public AudioSource music;
    public AudioSource intro;
	public Transform player;
	public GameObject dialogueDisplay;
    public GameObject tutorialDisplay;
    public GameObject button;
	public playerMove playerScript;
	public TextMeshProUGUI dialogue;
	public menuScript menuScript;
	public CanvasGroup canvas;
	private int primeInt = 1;
	void Awake()
	{
		playerScript.isMoving = false;
		music.Stop();
	
	}
    // Start is called before the first frame update
    void Start()
    {
        menuScript.isPlaying = false;
        canvas.interactable = false;
        //play idle Anim
    }

    // Update is called once per frame
    void Update()
    {
//    print(player.position.x);
        if (Input.GetKeyDown("space") && !menuScript.isPlaying)
        { 
	        Next(); 
        }
    }
    
    public void Next(){
     primeInt += 1;
        if (primeInt == 1){
                dialogue.text = "Isn’t this…";
        }
        else if (primeInt == 2){
        	dialogue.text = "My music editing software?! What the hell is going on?";
        }
       else if (primeInt ==3){
               dialogue.text = "I gotta get outta here! ";
        }
        else if (primeInt == 4){
              tutorialDisplay.SetActive(true);
              dialogueDisplay.SetActive(false);
        }
        else if(primeInt == 5)
        {
            playGame();
        }
    
    }
    
    public void playGame(){
    playerScript.isMoving = true;
    canvas.interactable = true;
    intro.Stop();
    menuScript.play();
     tutorialDisplay.SetActive(false);
     button.SetActive(false);
    
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class onLoad : MonoBehaviour
{
	public AudioSource music;
	public Transform player;
	public GameObject dialogueDisplay;
	public Text dialogue;
	public menuScript menuScript;
	private int primeInt = 1;
	void Awake()
	{
		Time.timeScale = 0.0f;
		music.Stop();
	
	}
    // Start is called before the first frame update
    void Start()
    {
        menuScript.isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
    print(player.position.x);
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
               playGame();
        }
    
    }
    
    public void playGame(){
    
    menuScript.play();
    dialogueDisplay.SetActive(false);
    
    }
}

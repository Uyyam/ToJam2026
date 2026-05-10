using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class dialogueScript : MonoBehaviour
{
        public AudioSource intro;
        public AudioSource transition;
	public GameObject scene11;
	public GameObject scene12;
	public GameObject scene13;
	public GameObject scene14;
	public GameObject scene15;
	public GameObject scene16;
	public GameObject scene17;
	public GameObject dialogueDisplay;
	public TextMeshProUGUI dialogue;
	private int primeInt = 1;
	private bool animPlaying = false;
	
    // Start is called before the first frame update
    void Start()
    {
        scene11.SetActive(true);
        scene12.SetActive(false);
        scene13.SetActive(false);
        scene14.SetActive(false);
        scene15.SetActive(false);
        scene16.SetActive(false);
        scene17.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                        if (Input.GetKeyDown("space")){
                        if(!animPlaying){
                      Next();
                      }
                      }
    }
    
    public void Next(){
        	 primeInt += 1;
        if (primeInt == 1){
                dialogue.text = "I’ve always been the type to sit in the background–y’know, not draw too much attention.";
        }
        else if (primeInt == 2){
        	dialogue.text = "My hair’s the type that’s long ‘cause it hides my face, not ‘cause I think it looks particularly good on me.";
        }
       else if (primeInt ==3){
               dialogue.text = "Y’know, the same length on all sides, cut straight across at the bottom–I’m getting side tracked.";
        }
       else if (primeInt == 4){
              dialogue.text = "What I should be focusing on is the song I’m supposed to be making. ";
               }
       else if (primeInt == 5){
                dialogue.text = "Oh yeah, I forgot to mention. I’m a producer. ";
        }
       else if (primeInt == 6){
               dialogue.text = "I’ve gotta help make a debut album for this cute girl who makes the type of pop music that you’d hear both in a club, or on an elementary school bus.  ";
        }
       else if (primeInt ==7){
                dialogue.text = "Fun, but safe. Y’know the vibe. ";
        }
       else if (primeInt == 8){
        	dialogue.text = "But God, for some reason, I just can’t get anything on paper. ";
        }
       else if (primeInt ==9){
       scene11.SetActive(false);
       scene12.SetActive(true);
               dialogue.text = "I’ve been staring at my music program blankly for hours, and nothing is coming to mind.";
        }
       else if (primeInt == 10){
              dialogue.text = "Nothing…";
               }
       else if (primeInt == 11){
                dialogue.text = "Nothing at all…";
        }
       else if (primeInt == 12){
       	scene12.SetActive(false);
       	scene13.SetActive(true);
        intro.Stop();
        transition.Play();
       	animPlaying = true;
       	dialogueDisplay.SetActive(false);
        }
       else if (primeInt ==13){
       scene13.SetActive(false);
       scene14.SetActive(true);
       animPlaying = false;
                dialogue.text = "Oh, shoot, I fell asleep!";
        }
       else if (primeInt == 14){
       scene14.SetActive(false);
       scene15.SetActive(true);
              dialogue.text = "Huh–I feel kinda… Funny… What?";
               }
       else if (primeInt == 15){
                dialogue.text = "...";
        }
       else if (primeInt == 16){
              scene15.SetActive(false);
       scene16.SetActive(true);
               dialogue.text = "I know for a fact I don’t own anything this vibrant.";
        }
       else if (primeInt ==17){

                dialogue.text = "It’s so… Out there.";
        }
       else if (primeInt == 18){
        	dialogue.text = "It’s so–it’s…";
        }
        else if (primeInt == 19){
        	dialogue.text = "I’m…";
        }

       else if (primeInt == 20){
        	dialogue.text = "I’m… Cute?";
        }

       else if (primeInt == 21){
        	dialogue.text = "Yeah, this outfit–it’s definitely…";
        }

       else if (primeInt == 22){
        	dialogue.text = "Really cute…! ";
        }

       else if (primeInt == 23){
       scene16.SetActive(false);
       scene17.SetActive(true);
        	dialogue.text = "“Hahaha–hah!” ";
        }

       else if (primeInt == 24){
        	dialogue.text = "Oh God, I probably look crazy, laughing to myself, but it’s not like anyone’s around.";
        }
         else if (primeInt == 25){
        	dialogue.text = "Wait–where am I?";
        }
        else if (primeInt == 26){
        	SceneManager.LoadScene("Base");
        }


    
    }
}

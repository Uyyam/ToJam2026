using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class endingDialogue : MonoBehaviour
{

	public GameObject scene21;
	public GameObject scene22;
        public GameObject scene23;

	public TextMeshProUGUI dialogue;
	private int primeInt = 1;

	
    // Start is called before the first frame update
    void Start()
    {
        scene21.SetActive(true);
        scene22.SetActive(false);
        scene23.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
                        if (Input.GetKeyDown("space")){
                      
                      Next();
                      
                      }
    }
    
    public void Next(){
        	 primeInt += 1;
        if (primeInt == 1){
                dialogue.text = "Woah–!";
        }
        else if (primeInt == 2){
        	dialogue.text = "What a crazy dream!";
        }
       else if (primeInt ==3){
               dialogue.text = "What time is it?";
        }
       else if (primeInt == 4){
              dialogue.text = "4:37AM…";
               }
       else if (primeInt == 5){
                dialogue.text = "Well–damn. I guess I should get to work on that album.";
        }
       else if (primeInt == 6){
               dialogue.text = "Actually...? Y’know what?";
        }
       else if (primeInt ==7){
        scene21.SetActive(false);
        scene22.SetActive(true);
                dialogue.text = "Let's set a reminder";
        }
       else if (primeInt == 8){
        	dialogue.text = "2:00PM. Call salon. Book appointment for cut and colour";
        }
       else if (primeInt ==9){
      
               dialogue.text = "I'm gonna go to bed, I deserve some rest'";
        }
       
        else if (primeInt == 10){
        	scene22.SetActive(false);

                dialogue.text = "The next day...";
        }
        else if(primeInt == 11)
                {
                scene23.SetActive(true);
                        dialogue.text = "I love it!";
                }
                else if(primeInt == 12)
                {
                        dialogue.text = "The End <3";
                }
                else if(primeInt == 13)
                {
                        SceneManager.LoadScene("Menu");
                }


    
    }
}

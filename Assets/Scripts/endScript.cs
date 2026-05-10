using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class endScript : MonoBehaviour
{
public playerMove playerMoveScript;
public Transform scrubber;
public GameObject dialogueDisplay;
public GameObject tutorialDisplay;
public TextMeshProUGUI dialogue;
private bool displayActive = false;
private bool isEnd = false;
private int primeInt = 1;

    void Update()
    {
        if (Input.GetKeyDown("space") && displayActive && isEnd){
                      Next();
                      }
    }
    
    public void Next(){
        if(isEnd){
     primeInt += 1;
        if (primeInt == 1){
                dialogue.text = "I think I made it!";
        }
        else if (primeInt == 2){
        	dialogue.text = "I've reached the end of the track!";
        }
       else if (primeInt ==3){
               dialogue.text = "I know how to finish the song! ";
        }
        else if (primeInt == 4){
               SceneManager.LoadScene("Ending");
        }
        }
    }
    
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        isEnd = true;
        tutorialDisplay.SetActive(false);
        playerMoveScript.isMoving = false;
        scrubber.position = new Vector3(0, 0, 0); // move the scrubber to the front
        //play idle anim
        dialogue.text = "I think I made it!";
        dialogueDisplay.SetActive(true);
        displayActive = true;
    }
}


}

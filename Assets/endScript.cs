using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class endScript : MonoBehaviour
{
public playerMove playerMoveScript;
public GameObject dialogueDisplay;
public Text dialogue;
private bool displayActive = false;
private int primeInt = 1;

    void Update()
    {
        if (Input.GetKeyDown("space") && displayActive){
                      Next();
                      }
    }
    
    public void Next(){
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
    
private void OnTriggerEnter2D(Collider2D other)
{
    if (other.gameObject.CompareTag("Player"))
    {
        playerMoveScript.isMoving = false;
        //play idle anim
        dialogueDisplay.SetActive(true);
        displayActive = true;
    }
}


}

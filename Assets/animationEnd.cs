using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationEnd : MonoBehaviour
{
	public GameObject dialogueDisplay;
	public dialogueScript dialogueScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void animEnd(){
    dialogueDisplay.SetActive(true);
    dialogueScript.Next();
    }
}

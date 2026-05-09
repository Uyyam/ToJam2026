using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{  
        public GameObject player;
    public GameObject scrubber;
    public Transform respawnPoint;   
    public AudioSource music;
     public const float scrubberOffset = -6f; 
    public void Setup()
    {
       // gameObject.SetActive(true);
    }

    public void RestartButton()
    { 
        // TODO: depends on how scene handled, May knows better for this
            player.transform.position = respawnPoint.position;
            music.Play(); // plays music back from the beginning when player respawns
            scrubber.transform.position = new Vector3(respawnPoint.position.x + scrubberOffset, scrubber.transform.position.y);
    }

    public void HomeButton()
    {  
        // if we want a home button
    }    
}

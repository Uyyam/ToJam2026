using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{  
        public GameObject player;
        public GameObject gameOverScreen;
    public GameObject scrubber;
    public Slider jumpSlider;
    public cameraScript camera;
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
            gameOverScreen.SetActive(false);
            Time.timeScale = 1f;
            music.Play(); // plays music back from the beginning when player respawns
            scrubber.transform.position = new Vector3(respawnPoint.position.x + scrubberOffset, scrubber.transform.position.y);
            Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
            rb.gravityScale = 5.0f; // reset gravity to normal when player respawns
            playerMove playerMoveScript = player.GetComponent<playerMove>();
            playerMoveScript.jumpForce = 14.0f; // reset jump force to normal
            jumpSlider.value = 0.5f;
            playerMoveScript.currentBPM = 140f; // reset BPM to normal
            camera.ResetCamera(player.transform.position.x, -3.73f); // reset camera to player position
        
    }

    public void HomeButton()
    {  
       SceneManager.LoadScene("Menu");
    }    
}

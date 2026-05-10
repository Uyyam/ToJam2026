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
    public speedScroll speedScript;
    public cameraScript camera;
    public gravityButton gravityButtonScript;
    public Transform respawnPoint;   
    public changeInstrument changeInstrumentScript;
    public AudioSource music;
     public const float scrubberOffset = -12f; 
    public void Setup()
    {
       // gameObject.SetActive(true);
    }


    public void RestartButton()
{
    // Reset gravity state explicitly, don't rely on the bool
    Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
    playerMove playerMoveScript = player.GetComponent<playerMove>();

    // Force gravity back to normal regardless of current state
    rb.gravityScale = Mathf.Abs(rb.gravityScale);       // always positive
    playerMoveScript.jumpForce = Mathf.Abs(playerMoveScript.jumpForce); // always positive

    // Reset gravity button visual state
    gravityButtonScript.gravityIsActive = true;
    gravityButtonScript.gravityInverted = 1.0f;
    ColorBlock cb = gravityButtonScript.button.colors;
    cb.normalColor = gravityButtonScript.baseColor; // or cache baseColor
    gravityButtonScript.button.colors = cb;
    gravityButtonScript.animator.SetTrigger("DisableGrav"); 

    // Reset position and physics
    player.transform.position = respawnPoint.position;
    rb.velocity = Vector2.zero;

    // Reset speed BEFORE playing music
    playerMoveScript.currentBPM = 140f;
    speedScript.currentValue = 0.5f;
    speedScript.changeSpeed(); // this sets pitch too
    speedScript.transform.rotation = speedScript.startingRotation;
    speedScript.fillBar.fillAmount =  speedScript.currentValue/speedScript.maxValue;

    // Now play music at the correct pitch
    music.Stop();
    music.Play();

    // Rest of resets
    gameOverScreen.SetActive(false);
    Time.timeScale = 1f;
    scrubber.transform.position = new Vector3(respawnPoint.position.x + scrubberOffset, scrubber.transform.position.y);
    playerMoveScript.jumpForce = 18.0f;
    jumpSlider.value = 0.37f;
    camera.ResetCamera(player.transform.position.x, -3.73f);
    changeInstrumentScript.selectedInstrument = 1;
    changeInstrumentScript.hitCollider1 = false;
    changeInstrumentScript.hitCollider2 = false;

        
    }

    public void HomeButton()
    {  
       SceneManager.LoadScene("Menu");
    }    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{

    public AudioSource music;
    public GameObject gameOverScreen;

    //current distance between scrubber and player, respawns relative to player position

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {

        
        if(other.gameObject.CompareTag("Player"))
        {
            //Here we want to make the game over screen pop up, and then have the option to restart the level or go back to the main menu
            music.Stop(); // Stops music when player dies
            gameOverScreen.SetActive(true);
            Time.timeScale = 0f;
            // this code we can then move to when the player presses the restart button (to respawn)
            // player.transform.position = respawnPoint.position;
            // music.Play(); // plays music back from the beginning when player respawns
            // scrubber.transform.position = new Vector3(respawnPoint.position.x + scrubberOffset, scrubber.transform.position.y);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject player;
    public GameObject scrubber;
    public Transform respawnPoint;

    //current distance between scrubber and player, respawns relative to player position
    public const float scrubberOffset = -6f; 
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
            // TODO: have music rewind to position - make camera jump(?) to respawn point
            player.transform.position = respawnPoint.position;
            scrubber.transform.position = new Vector3(respawnPoint.position.x + scrubberOffset, scrubber.transform.position.y);
        }
    }
}

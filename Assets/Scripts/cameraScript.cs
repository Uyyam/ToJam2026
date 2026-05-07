using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform player;
    public float speed = 0.125f;
    public Vector3 offset;
    
    private float startFollowingX = 0.0f;
    private bool isFollowing = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isFollowing && player.position.x >= startFollowingX)
        {
            isFollowing = true;
        }

        if (isFollowing)
        {
            var desiredPosition = player.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, speed);
            
            var clampedY = new Vector3 (smoothedPosition.x, transform.position.y, transform.position.z);
            transform.position = clampedY;

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour
{
    public Transform player;
    public Transform canvas;
    public float speed = 0.125f;
    public Vector3 offset;
    public bool isFollowing = false;
    private float startFollowingX = 0.0f;
    private Vector3 velocity = new Vector3(0, 0, 0);
    

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
            var smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, speed);
            
            var clampedY = new Vector3 (smoothedPosition.x, transform.position.y, transform.position.z);
            transform.position = clampedY;

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class moveScrubber : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
public cameraScript cameraScript;
public playerMove playerMoveScript;
public AudioSource ouch;
public GameObject gameOverScreen;
private bool isDragging = false;
private float previousPositionX;
private float currentPositionX; 
public RectTransform rectTransform; 
public Canvas canvas;
 public AudioSource music;
 public AudioSource source;
public AudioClip clip;
public Animator animator;
    // Start is called before the first frame update
void Start()
    {
    StartCoroutine(AudioClipReverse.CreateReversedCoroutine(clip, reversed =>
    	{
    	if (reversed == null){
    	return;
    	}
    	source.clip = reversed;
    	}));
    }
    // Update is called once per frame
void Update()
    {
        animator.SetBool("scrubber_held", isDragging);
        if(cameraScript.isFollowing)
        { 
            transform.Translate(new Vector2(x:playerMoveScript.speed * Time.deltaTime, y:0));
        }
        //check if hit player
        
        if(transform.position.x > playerMoveScript.transform.position.x - 0.5f && transform.position.x < playerMoveScript.transform.position.x + 0.5f)
        {
            music.Stop(); // Stops music when player dies
            gameOverScreen.SetActive(true);
            ouch.Play(); // Plays ouch sound effect when player dies
        
            Time.timeScale = 0f;
        }

    }
public void OnPointerDown(PointerEventData eventData)
        { 
            isDragging = true; 
            previousPositionX = eventData.position.x; 
            print("Pointer Down: " + eventData.position);
        }
public void OnDrag(PointerEventData eventData)
    { 
        if (!isDragging) return;
        // Debug.Log("Dragging: " + eventData.position);
        currentPositionX = eventData.position.x;
        float deltaX = currentPositionX - previousPositionX;    
        previousPositionX = currentPositionX;
        // print("Event Position X: " + eventData.position.x);
        // print("Transform Position: " + transform.position.x);
        if (deltaX < 0)
        {
            //make scrubber move where mouse is and make speed relative to scrub speed
            playerMoveScript.speed = -Mathf.Abs(playerMoveScript.speed);
            float clampedX = Mathf.Clamp(eventData.position.x, 250f, 420f);
            Vector2 clampedPosition = new Vector3(clampedX, eventData.position.y);
            MoveScrubberToMouse(clampedPosition);
            if(!source.isPlaying){
		source.time = music.clip.length - music.time;
        source.Play();
		}
		music.Pause();
        }
        // else{
        //     if(eventData.position.x < startPositionMouse)
        //     {
        //          print("Slow down speed");
        //          MoveScrubberToMouse(eventData.position);
        //          playerMoveScript.speed = -Mathf.Abs(initialPlayerSpeed) * 0.5f;
        //     }
               
        // }
    }
public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
        playerMoveScript.speed = Mathf.Abs(playerMoveScript.speed);
        music.time = source.clip.length - source.time;
        music.Play();
source.Stop();
    }

    private void MoveScrubberToMouse(Vector2 screenPosition)
    {
        // Convert screen position to canvas local position
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            screenPosition,
            canvas.worldCamera,
            out Vector2 localPoint
        );

        // Only move on X axis, keep Y fixed
        // Debug.Log(localPoint.x);
        // localPoint.x = Mathf.Clamp(localPoint.x, 0.3f, 3.7f);
        rectTransform.localPosition = new Vector2(localPoint.x, rectTransform.localPosition.y);
    }
}

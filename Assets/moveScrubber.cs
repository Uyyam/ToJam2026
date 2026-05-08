using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class moveScrubber : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{
public cameraScript cameraScript;
public playerMove playerMoveScript;
private bool isDragging = false;
private float previousPositionX;
private float currentPositionX;
private float startPositionX;
 public RectTransform rectTransform;
    public Canvas canvas;
    // Start is called before the first frame update
void Start()
    {
    }
    // Update is called once per frame
void Update()
    {
if(cameraScript.isFollowing)
        {
transform.Translate(new Vector2(x:playerMoveScript.speed * Time.deltaTime, y:0));
        }
    }
public void OnPointerDown(PointerEventData eventData)
        {
isDragging = true;
previousPositionX = eventData.position.x;
startPositionX = eventData.position.x;
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
if(deltaX < 0)
            {
                //make scrubber move where mouse is and make speed relative to scrub speed
playerMoveScript.speed = -Mathf.Abs(playerMoveScript.speed);
MoveScrubberToMouse(eventData.position);
            }
            else{
                if(eventData.position.x < startPositionX)
                {
                     print("Slow down speed");
                }
               
    }
    }
public void OnPointerUp(PointerEventData eventData)
    {
isDragging = false;
playerMoveScript.speed = Mathf.Abs(playerMoveScript.speed);
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
        rectTransform.localPosition = new Vector2(localPoint.x, rectTransform.localPosition.y);
    }
}
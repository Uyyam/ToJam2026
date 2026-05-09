using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class speedScroll : MonoBehaviour,IPointerDownHandler, IDragHandler, IPointerUpHandler
{   
    public float minValue = 0f;
    public float maxValue = 1f;
    public float currentValue = 0.5f;

    public playerMove playerMoveScript;
    public Text BPMText;
    public AudioSource music;
    public AudioSource reverse;
    private bool isDragging = false;
    private float previousAngle;
    // Start is called before the first frame update
    public UnityEngine.Events.UnityEvent<float> onValueChanged;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        previousAngle = GetAngleFromMouse(eventData.position);
        Debug.Log("Pointer Down: " + previousAngle);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isDragging) return;
        // Debug.Log("Dragging: " + eventData.position);

        float currentAngle = GetAngleFromMouse(eventData.position);
        float delta = Mathf.DeltaAngle(previousAngle, currentAngle);
        previousAngle = currentAngle;

        // Rotate the visual
        if(currentValue >0 && currentValue < 1){
        transform.Rotate(0, 0, -delta);
        }

        // Update value
        float valueRange = maxValue - minValue;
        currentValue += (delta / 360f) * valueRange;
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        
    

        onValueChanged?.Invoke(currentValue);
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isDragging = false;
    }

    private float GetAngleFromMouse(Vector2 mousePosition)
    {
        Vector2 direction = mousePosition - (Vector2)transform.position;
        return Mathf.Atan2(direction.y, direction.x) * -Mathf.Rad2Deg;
    }

    public void changeSpeed()
    {
         float newBPM = Mathf.Lerp(70, 210, Mathf.InverseLerp(0, 1, currentValue));

        playerMoveScript.currentBPM = newBPM;

        playerMoveScript.speed = (playerMoveScript.currentBPM / 60f) * playerMoveScript.unitsPerBeat;
        BPMText.text = Mathf.RoundToInt(newBPM).ToString() + " BPM";
        music.pitch = Mathf.Lerp(0.5f, 1.5f, Mathf.InverseLerp(70, 210, newBPM));
        reverse.pitch = music.pitch;

    }
}


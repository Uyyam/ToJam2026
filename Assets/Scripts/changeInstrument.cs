using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeInstrument : MonoBehaviour
{
    public Camera camera;
    public Transform player;
    public float panHeight = 5.0f;
    public jumpSliderScript jumpSlider;
    public AudioSource inst1;
    public AudioSource inst2;
    public AudioSource inst3;
    public Button instrument1;
    public Button instrument2;
    public Button instrument3;
    public bool hitCollider1 = false;
    public bool hitCollider2 = false;
    public int selectedInstrument = 1;
    private Rigidbody2D playerRb;

    // Start is called before the first frame update
    void Start()
    {
    instrument2.interactable = false;
    instrument3.interactable = false; // set some triggers for them to become true
    instrument1.interactable = false; // default to instrument 1, so all buttons are disabled until you hit a collider
    playerRb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(selectedInstrument);
        if(hitCollider1){
        if(selectedInstrument == 1)
        {
            instrument1.interactable = false;
            instrument2.interactable = true;
             if(hitCollider2){
            instrument3.interactable = true;
            }
                else
                {
                    instrument3.interactable = false;
                }
        }
        else if(selectedInstrument == 2)
        {
            instrument1.interactable = true;
            instrument2.interactable = false;
            if(hitCollider2){
            instrument3.interactable = true;
            }
                else
                {
                    instrument3.interactable = false;
                }
        }
        else if(selectedInstrument == 3)
        {
            instrument1.interactable = true;
            instrument2.interactable = true;
            instrument3.interactable = false;
        }
        }
        else
        {
            instrument1.interactable = false;
            instrument2.interactable = false;
            instrument3.interactable = false;
        }

        if(player.position.y > -15.5f && player.position.y < 5.0f)
        {
            selectedInstrument = 1;
        }
        else if (player.position.y < -15.5f)
        {
            selectedInstrument = 2;
        }
        else if (player.position.y > 5.0f)
        {
            selectedInstrument = 3;
        }
    }


private IEnumerator PanCamera(float targetY, float duration)
{
    float startY = camera.transform.position.y;
    float elapsed = 0f;

    // Disable physics during transition
    playerRb.simulated = false;

    while (elapsed < duration)
    {
        elapsed += Time.deltaTime;
        float t = elapsed / duration;
        t = t * t * (3f - 2f * t); // smoothstep

        float newY = Mathf.Lerp(startY, targetY, t);

        
        camera.transform.position = new Vector3(player.position.x, newY, camera.transform.position.z);
        player.position = new Vector3(player.position.x, camera.transform.position.y, player.position.z);

        yield return null;
    }

    // Teleport player to new lane using Rigidbody so it respects the new position
    playerRb.position = new Vector2(player.position.x, targetY);
    playerRb.velocity = Vector2.zero; // clear any existing velocity

    // Re-enable physics so they land on the platform naturally
    playerRb.simulated = true;

    camera.transform.position = new Vector3(player.position.x, targetY, camera.transform.position.z);
    jumpSlider.playerStartY = targetY;
}

public void changeTo1()
{
    StopAllCoroutines(); 
    StartCoroutine(PanCamera(-3.73f, 2f));
    selectedInstrument = 1;
    inst1.Play();
}

public void changeTo2()
{
    StopAllCoroutines();
    StartCoroutine(PanCamera(-3.73f - panHeight, 2f));
    selectedInstrument = 2;
    inst2.Play();

}

public void changeTo3()
{
    StopAllCoroutines();
    StartCoroutine(PanCamera(-3.73f + panHeight, 2f));
    selectedInstrument = 3;
    inst3.Play();

}

}

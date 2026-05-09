using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeInstrument : MonoBehaviour
{
    public Camera camera;
    public Transform player;
    public float panHeight = 5.0f;
    public jumpSliderScript jumpSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

private IEnumerator PanCamera(float targetY, float duration)
{
    float startY = camera.transform.position.y;
    float elapsed = 0f;

    while (elapsed < duration)
    {
        elapsed += Time.deltaTime;
        float t = elapsed / duration;

        // Y pans to target, X follows player in real time
        float newY = Mathf.Lerp(startY, targetY, t);
        camera.transform.position = new Vector3(player.position.x, newY, camera.transform.position.z);
        player.position = camera.transform.position;

        yield return null;
    }

    camera.transform.position = new Vector3(player.position.x, targetY, camera.transform.position.z);
   // player.position = camera.transform.position; // we gotta move the player character up somehow...
    jumpSlider.playerStartY = targetY;
}

public void changeTo1()
{
    StopAllCoroutines(); 
    StartCoroutine(PanCamera(-3.73f, 2f));
}

public void changeTo2()
{
    StopAllCoroutines();
    StartCoroutine(PanCamera(-3.73f + panHeight, 2f));

}

public void changeTo3()
{
    StopAllCoroutines();
    StartCoroutine(PanCamera(-3.73f - panHeight, 2f));
}

}

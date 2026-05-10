using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuScript : MonoBehaviour
{
    public AudioSource music;
    public Button playButton;
    public Button pauseButton;
    public bool isPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlaying)
        {
            playButton.interactable = false;
            pauseButton.interactable = true;
        }
        else
        {
            playButton.interactable = true;
            pauseButton.interactable = false;
        }
    }

    public void play()
    {
        if (!isPlaying)
        {
            Time.timeScale = 1f;
        music.Play();
        }
        isPlaying = true;

        
    }

    public void pause()
    {
        if (isPlaying)
        {
            Time.timeScale = 0f;
        music.Pause();
        }
        isPlaying = false;

        
    }

}

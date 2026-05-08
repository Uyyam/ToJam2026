using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speedScroll : MonoBehaviour
{    public Scrollbar scrollbar;
    public playerMove playerMoveScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeSpeed()
    {
        playerMoveScript.speed = Mathf.Lerp(4, 20, Mathf.InverseLerp(0, 1, scrollbar.value));
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class GameOver : MonoBehaviour
{  
    public void Setup()
    {
        gameObject.SetActive(true);
    }

    public void RestartButton()
    { 
        // TODO: depends on how scene handled, May knows better for this
    }

    public void HomeButton()
    {  
        // if we want a home button
    }    
}

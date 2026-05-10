using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instrumentCollider : MonoBehaviour
{
    public changeInstrument changeInstrumentScript;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (gameObject.name == "Instrument2")
            {
                changeInstrumentScript.hitCollider1 = true;
                changeInstrumentScript.selectedInstrument = 2;
                changeInstrumentScript.changeTo2();
            }
            else if (gameObject.name == "Instrument3")
            {   
                changeInstrumentScript.hitCollider2 = true;
                changeInstrumentScript.selectedInstrument = 3;
                changeInstrumentScript.changeTo3();
            }
        }
    }
}

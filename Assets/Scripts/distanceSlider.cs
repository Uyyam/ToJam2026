using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distanceSlider : MonoBehaviour
{
	public Transform player;
	public Transform start;
	public Transform end;
	public Slider distSlider;
	public Text distText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        updateProgress();
    }
    
    public void updateProgress(){
    	var totalDist = end.position.x + Mathf.Abs(start.position.x);
    	var percentage = (player.position.x - start.position.x)/totalDist * 100;
    	distSlider.value = percentage/100;
    	distText.text =  Mathf.RoundToInt(percentage).ToString() + "%";
    }
}

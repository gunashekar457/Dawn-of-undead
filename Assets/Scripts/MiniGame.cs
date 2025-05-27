using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGame : MonoBehaviour
{
    public Slider slider;
    public bool buttonPressed;
    public float lerpDuration = 2.0f;
    private float lerpTime;
    private bool increasing = true;

    void Start()
    {
        slider.value = 0f;
        lerpTime = 0;
        buttonPressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if(!buttonPressed && slider.value<100f)
        //{
        //    slider.value += Mathf.Lerp(slider.value, slider.value + Time.deltaTime,2f*Time.deltaTime);
        //}
        //else if(!buttonPressed && slider.value>100f)
        //{

        //}
        float cycleFraction = lerpTime / lerpDuration;

        // Update slider value based on whether it's increasing or decreasing
        if (increasing && !buttonPressed)
        {
            slider.value = Mathf.Lerp(0, 100, cycleFraction);
        }
        else if(!increasing && !buttonPressed)
        {
            slider.value = Mathf.Lerp(100, 0, cycleFraction);
        }

        // Update the time for this frame
        lerpTime += Time.deltaTime;

        // Check if we need to switch direction
        if (lerpTime >= lerpDuration)
        {
            lerpTime = 0;
            increasing = !increasing; // Toggle the direction
        }
    }

    public void StopPressed()
    {
        buttonPressed = true;
        if(slider.value>62 && slider.value <=78)
        {
            GameManager.instance.EnableGameState(code.GameState.GoToHelipad);
        }
        else
        {
            buttonPressed = false;
            slider.value = 0;
        }
    }
}

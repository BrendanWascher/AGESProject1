using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clock : MonoBehaviour
{
    [SerializeField]
    private Text timeText;

    private float totalTime;

	// Use this for initialization
	void Start ()
    {
        totalTime = GameTimer.timeRemaining; 
	}
	
	// Update is called once per frame
	void Update ()
    {
        UpddateTimer();
	}

    private void UpddateTimer()
    {
        if(GameTimer.timeRemaining >= 10)
            timeText.text = Math.Round((GameTimer.timeRemaining),0).ToString();
        else
            timeText.text = Math.Round((GameTimer.timeRemaining), 1).ToString();
    }


    private void ChangeClockColor()
    {
        // TODO change clock's color based on time remaining
    }
}

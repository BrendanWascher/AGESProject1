using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private static float timeRemaining;
    public static float startTimer;
    public static bool isTimeUp;
    public static bool hasStarted;
	
	void Start ()
    {
        timeRemaining = 90f;
        isTimeUp = false;
        hasStarted = false;
        startTimer = 3f;
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeUp();
	}

    private static void TimeUp()
    {
        if (timeRemaining > 0 && hasStarted)
        {
            timeRemaining -= Time.deltaTime;
        }
        else if (startTimer <= 0 && !hasStarted)
        {
            hasStarted = true;
        }
        else if (!hasStarted)
        {
            startTimer -= Time.deltaTime;
        }
        else
        {
            isTimeUp = true;
            timeRemaining = 90f;
            hasStarted = false;
        }

        Debug.Log(timeRemaining);
        //Debug.Log(startTimer);

    }
}

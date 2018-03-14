using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public static float timeRemaining = 3f;
    public static float startTimer = 3f;
    public static bool isPaused = false;
    [HideInInspector] public static bool isTimeUp;
    [HideInInspector] public static bool hasStarted;
	
	void Start ()
    {
        isTimeUp = false;
        hasStarted = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        TimeUp();
	}

    private static void TimeUp()
    {
        if (!isPaused)
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
                timeRemaining = 3f;
                hasStarted = false;
            }
        }

        //Debug.Log(timeRemaining);
        //Debug.Log(startTimer);

    }
}

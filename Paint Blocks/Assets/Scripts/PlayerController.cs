using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float gridUpperXLimit = 10.5f;

    [SerializeField]
    private float gridUpperZLimit = 8.5f;

    [SerializeField]
    private float gridLowerXLimit = 1.5f;

    [SerializeField]
    private float gridLowerZLimit = -0.5f;

    [SerializeField]
    private GameObject playerGameObject;

    [SerializeField]
    private Animator animator;

    private float curXCoord = 2.5f;
    private float curZCoord = .5f;

    private int playerNumber = 1;

    private bool isButtonPressed = false;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        //gameObject = GetComponent<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        GetInput();
	}

    private void GetInput()
    {
        CheckPressed();
        CheckReleased();
    }

    private void CheckPressed()
    {
        if(!isButtonPressed)
        {
            if (Input.GetButtonDown("Horizontal" + playerNumber))
            {
                if (Input.GetAxis("Horizontal" + playerNumber) > 0
                    && curZCoord < gridUpperZLimit)
                {
                    isButtonPressed = true;
                    //animator.SetBool("isPlayerMovingRight", true);
                    //MoveRight();
                    gameObject.transform.Translate(0f, 0f, 1f);
                    playerGameObject.transform.Rotate(90f, 0f, 0f);
                    curZCoord++;

                    Debug.Log("Z coord is " +curZCoord);
                }
                else if (Input.GetAxis("Horizontal" + playerNumber) < 0
                    && curZCoord > gridLowerZLimit)
                {
                    isButtonPressed = true;
                    //animator.SetBool("isPlayerMovingLeft", true);
                    //MoveLeft();
                    gameObject.transform.Translate(0f, 0f, -1f);
                    playerGameObject.transform.Rotate(-90f, 0f, 0f);
                    curZCoord--;

                    Debug.Log("Z coord is " + curZCoord);
                }
            }
            else if(Input.GetButtonDown("Vertical" + playerNumber))
            {
                if(Input.GetAxis("Vertical" + playerNumber) > 0
                    && curXCoord > gridLowerXLimit)
                {
                    isButtonPressed = true;
                    //animator.SetBool("isPlayerMovingUp", true);
                    //MoveDown();
                    gameObject.transform.Translate(-1f, 0f, 0f);
                    playerGameObject.transform.Rotate(0f, 0f, 90f);
                    curXCoord--;

                    Debug.Log("X coord is " + curXCoord);
                }
                else if(Input.GetAxis("Vertical" + playerNumber) < 0
                    && curXCoord < gridUpperXLimit)
                {
                    isButtonPressed = true;
                    //animator.SetBool("isPlayerMovingDown", true);
                    //MoveUp();
                    gameObject.transform.Translate(1f, 0f, 0f);
                    playerGameObject.transform.Rotate(0f, 0f, -90f);
                    curXCoord++;

                    Debug.Log("X coord is " + curXCoord);
                }
            }
        }
    }

    private void CheckReleased()
    {
        if ((Input.GetButtonUp("Horizontal" + playerNumber)) || 
            (Input.GetButtonUp("Vertical" + playerNumber)))
        {
            isButtonPressed = false;
            /*
            animator.SetBool("isPlayerMovingRight", false);
            animator.SetBool("isPlayerMovingLeft", false);
            animator.SetBool("isPlayerMovingUp", false);
            animator.SetBool("isPlayerMovingDown", false);
            */
        }
    }

    private void MoveRight()
    {
        for(int i = 1; i <= 90; i++ )
        {
            gameObject.transform.Rotate(1f, 0f, 0f);
            if(i<=45)
            {
                gameObject.transform.Translate(0f, .1f, .1f);
            }
            else
            {
                gameObject.transform.Translate(0f, -.1f, .1f);
            }
        }
        gameObject.transform.Translate(0f, 0f, .1f);
    }

    private void MoveLeft()
    {
        for (int i = 1; i <= 90; i++)
        {
            gameObject.transform.Rotate(-1f, 0f, 0f);
            if (i <= 45)
            {
                gameObject.transform.Translate(0f, .1f, -.1f);
            }
            else
            {
                gameObject.transform.Translate(0f, -.1f, -.1f);
            }
        }
        gameObject.transform.Translate(0f, 0f, -.1f);
    }

    private void MoveUp()
    {
        for (int i = 1; i <= 90; i++)
        {
            gameObject.transform.Rotate(0f, 0f, 1f);
            if (i <= 45)
            {
                gameObject.transform.Translate(-.1f, .1f, 0f);
            }
            else
            {
                gameObject.transform.Translate(-.1f, -.1f, 0f);
            }
        }
        gameObject.transform.Translate(-.1f, 0f, 0f);
    }

    private void MoveDown()
    {
        for (int i = 1; i <= 90; i++)
        {
            gameObject.transform.Rotate(0f, 0f, -1f);
            if (i <= 45)
            {
                gameObject.transform.Translate(.1f, .1f, 0f);
            }
            else
            {
                gameObject.transform.Translate(.1f, -.1f, 0f);
            }
        }
        gameObject.transform.Translate(.1f, 0f, 0f);
    }
}

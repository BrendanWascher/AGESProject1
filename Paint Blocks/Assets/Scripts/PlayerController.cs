using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField]
    private GameObject side1, side2, side3, side4, side5, side6;

    [SerializeField]
    private Text playerUIText;

    private float curXCoord = 2.5f;
    private float curZCoord = .5f;

    private int playerNumber = 1;

    private bool isButtonPressed = false;

	void Start ()
    {
        animator = GetComponent<Animator>();

        playerUIText.text = "Player " + playerNumber;
    }
	
	void Update ()
    {
        GetInput();

        //Debug.Log("Update in Player Controller Called");
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
                    MoveRight();
                }
                else if (Input.GetAxis("Horizontal" + playerNumber) < 0
                    && curZCoord > gridLowerZLimit)
                {
                    isButtonPressed = true;
                    MoveLeft();
                }
            }
            else if(Input.GetButtonDown("Vertical" + playerNumber))
            {
                if(Input.GetAxis("Vertical" + playerNumber) > 0
                    && curXCoord > gridLowerXLimit)
                {
                    isButtonPressed = true;
                    MoveDown();
                }
                else if(Input.GetAxis("Vertical" + playerNumber) < 0
                    && curXCoord < gridUpperXLimit)
                {
                    isButtonPressed = true;
                    MoveUp();
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
        //animator.SetBool("isPlayerMovingRight", true);
        gameObject.transform.Translate(0f, 0f, 1f);
        playerGameObject.transform.Rotate(90f, 0f, 0f, Space.World);
        curZCoord++;

        Debug.Log("Z coord is " + curZCoord);
    }

    private void MoveLeft()
    {
        //animator.SetBool("isPlayerMovingLeft", true);
        gameObject.transform.Translate(0f, 0f, -1f);
        playerGameObject.transform.Rotate(-90f, 0f, 0f, Space.World);
        curZCoord--;

        Debug.Log("Z coord is " + curZCoord);
    }

    private void MoveUp()
    {
        //animator.SetBool("isPlayerMovingDown", true);
        gameObject.transform.Translate(1f, 0f, 0f);
        playerGameObject.transform.Rotate(0f, 0f, -90f, Space.World);
        curXCoord++;

        Debug.Log("X coord is " + curXCoord);
    }

    private void MoveDown()
    {
        //animator.SetBool("isPlayerMovingUp", true);
        gameObject.transform.Translate(-1f, 0f, 0f);
        playerGameObject.transform.Rotate(0f, 0f, 90f, Space.World);
        curXCoord--;

        Debug.Log("X coord is " + curXCoord);
    }
}

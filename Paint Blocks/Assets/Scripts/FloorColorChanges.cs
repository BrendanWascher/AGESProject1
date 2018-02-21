using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColorChanges : MonoBehaviour
{
    [SerializeField]
    private Renderer renderer;

    [SerializeField]
    private GameObject player1;

    /*
    [SerializeField]
    private GameObject player2;

    [SerializeField]
    private GameObject player3;

    [SerializeField]
    private GameObject player4;  
    */

    private GameObject playerChild;

    private Renderer childRenderer;

    private Color clear;

    private bool isPlayerOne = false;
    private bool isPlayerTwo = false;
    private bool isPlayerThree = false;
    private bool isPlayerFour = false;

	// Use this for initialization
	void Start ()
    {
        clear = Color.white;
        renderer.material.color = clear;
	}

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Contact with ground");

        if (col.gameObject.tag == "Player1")
        {
            isPlayerOne = true;
        }
        else if (col.gameObject.tag == "Player2")
        {
            isPlayerTwo = true;
        }
        else if(col.gameObject.tag == "Player3")
        {
            isPlayerThree = true;
        }
        else if(col.gameObject.tag == "Player4")
        {
            isPlayerFour = true;
        }
        else
        {
            Debug.Log("Error. Unknown Player");
        }
        PlayerCollision();
    }

    private void PlayerCollision()
    {
        if (isPlayerOne || isPlayerTwo || isPlayerThree || isPlayerFour)
        {
            CheckAllChildren();
            if (renderer.material.color == clear)
            {
                renderer.material.color = childRenderer.material.color;
                childRenderer.material.color = clear;
            }
            else if (childRenderer.material.color == clear)
            {
                childRenderer.material.color = renderer.material.color;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("On Trigger Enter Called");
    }

    private void CheckAllChildren()
    {
        Vector3 bottom = new Vector3(0, 0, 0);

        if(isPlayerOne)
        {
            foreach (GameObject child in player1.transform)
            {
                if (child.transform.position == bottom)
                {
                    playerChild = child;
                }
            }
            isPlayerOne = false;
        }
        /*
        else if (isPlayerTwo)
        {
            foreach (GameObject child in player2.transform)
            {
                if (child.transform.position == bottom)
                {
                    playerChild = child;
                }
            }
            isPlayerTwo = false;
        }
        else if(isPlayerThree)
        {
            foreach (GameObject child in player3.transform)
            {
                if (child.transform.position == bottom)
                {
                    playerChild = child;
                }
            }
            isPlayerThree = false;
        }
        else if(isPlayerFour)
        {
            foreach (GameObject child in player4.transform)
            {
                if (child.transform.position == bottom)
                {
                    playerChild = child;
                }
            }
            isPlayerFour = false;
        }
        */

        childRenderer = playerChild.GetComponent<Renderer>();        
    }
}

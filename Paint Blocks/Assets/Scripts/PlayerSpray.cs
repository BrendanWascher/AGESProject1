using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpray : MonoBehaviour
{
    [SerializeField]
    private PlayerController player;

    [SerializeField]
    private GameObject paintSpray;

    [SerializeField]
    private Renderer paintRenderer;

    [SerializeField]
    private float coolDown = 5f;

    [SerializeField]
    private ParticleSystem spray;

    private ParticleSystemRenderer sprayColor;

    string lastDirectionMoved;

    private bool isOnCoolDown = false;
    private int playerNumber;
    private float timer;

	void Start ()
    {
        playerNumber = player.playerNumber;
        sprayColor = GetComponent<ParticleSystemRenderer>();
        sprayColor.material = player.playerMaterial;
	}
	
	void Update ()
    {
        lastDirectionMoved = player.lastDirectionMoved;
        paintRenderer.material = player.playerMaterial;
        CheckInput();
	}

    private void CheckInput()
    {
        //Debug.Log(isOnCoolDown);

        if(Input.GetButtonDown("Fire"+playerNumber))
        {
            if(!isOnCoolDown)
            {
                if (lastDirectionMoved == "Right")
                    SprayRight();
                else if (lastDirectionMoved == "Left")
                    SprayLeft();
                else if (lastDirectionMoved == "Up")
                    SprayUp();
                else if (lastDirectionMoved == "Down")
                    SprayDown();
                else
                    SprayDown();

                isOnCoolDown = true;
                StartCoroutine(CoolDown());
            }
        }
    }

    private IEnumerator CoolDown()
    {
        timer = 0f;

        while(!CoolDownTimer())
        {
            yield return null;
        }

        Debug.Log("No longer on cooldown");
        isOnCoolDown = false;
    }

    private bool CoolDownTimer()
    {
        timer += Time.deltaTime;
        if(timer<coolDown)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SprayRight()
    {
        // don't rotate object
        // move object forward
        Debug.Log("Sprayed towards the " + lastDirectionMoved);
        spray.Play();

        paintRenderer.transform.Translate(0f, -.33f, 0f);
        for (int i = 0; i < 4; i++)
        {
            paintRenderer.transform.Translate(0f, 0f, 1f);
        }
        paintRenderer.transform.Translate(0f, .33f, 0f);
        paintRenderer.transform.Translate(0f, 0f, -4f);

        // don't rotate object back
    }

    private void SprayLeft()
    {
        // rotate object 180 in y
        paintSpray.transform.Rotate(0, 180, 0);
        // move object forward
        Debug.Log("Sprayed towards the " + lastDirectionMoved);
        spray.Play();

        paintRenderer.transform.Translate(0f, -.33f, 0f);
        for (int i = 0; i < 4; i++)
        {
            paintRenderer.transform.Translate(0f, 0f, 1f);
        }
        paintRenderer.transform.Translate(0f, .33f, 0f);
        paintRenderer.transform.Translate(0f, 0f, -4f);

        // rotate object -180 in y
        paintSpray.transform.Rotate(0, -180, 0);
    }

    private void SprayUp()
    {
        // rotate object -90 in y
        paintSpray.transform.Rotate(0, -90, 0);
        // move object forward
        Debug.Log("Sprayed towards the " + lastDirectionMoved);
        spray.Play();

        paintRenderer.transform.Translate(0f, -.33f, 0f);
        for (int i = 0; i < 4; i++)
        {
            paintRenderer.transform.Translate(0f, 0f, 1f);
        }
        paintRenderer.transform.Translate(0f, .33f, 0f);
        paintRenderer.transform.Translate(0f, 0f, -4f);

        // rotate object 90 in y
        paintSpray.transform.Rotate(0, 90, 0, Space.World);
    }

    private void SprayDown()
    {
        // rotate object 90 in y
        paintSpray.transform.Rotate(0, 90, 0);
        // move object forward
        Debug.Log("Sprayed towards the " + lastDirectionMoved);
        spray.Play();

        paintRenderer.transform.Translate(0f, -.33f, 0f);
        for (int i = 0; i < 4; i++)
        {
            paintRenderer.transform.Translate(0f, 0f, 1f);
        }
        paintRenderer.transform.Translate(0f, .33f, 0f);
        paintRenderer.transform.Translate(0f, 0f, -4f);

        // rotate object -90 in y
        paintSpray.transform.Rotate(0, -90, 0);
    }

    // make spray IEnumerator
    // moves too fast 
}

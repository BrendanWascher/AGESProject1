﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorColorChanges : MonoBehaviour
{
    [SerializeField]
    private Renderer renderer;

    [SerializeField]
    private Material player1Material;

    [SerializeField]
    private Material player2Material;

    [SerializeField]
    private Material player3Material;

    [SerializeField]
    private Material player4Material;

    private GameObject playerGameObject;

    private Renderer playerRenderer;

    private Material previousMaterial;

    private Color clear;

    private bool isPlayerOne = false;
    private bool isPlayerTwo = false;
    private bool isPlayerThree = false;
    private bool isPlayerFour = false;

    private string playerTag;
    private string lastPlayertag;

    public static int player1Count;
    public static int player2Count;
    public static int player3Count;
    public static int player4Count;

	// Use this for initialization
	void Start ()
    {
        clear = Color.white;
        renderer.material.color = clear;

        player1Count = 0;
        player2Count = 0;
        player3Count = 0;
        player4Count = 0;
	}

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("Contact with ground");

        ChangeColor(collider);
    }

    private void ChangeColor(Collider col)
    {
        playerGameObject = col.gameObject;
        playerRenderer = playerGameObject.GetComponent<Renderer>();

        if (renderer.material.color == clear)
        {
            renderer.material.color = playerRenderer.material.color;
            playerRenderer.material.color = clear;
            UpdatePlayerCount(true);
        }
        else if (playerRenderer.material.color == clear)
        {
            playerRenderer.material.color = renderer.material.color;
        }
        else if(playerRenderer.material.color != renderer.material.color)
        {
            UpdatePlayerCount(false);
            renderer.material.color = playerRenderer.material.color;
            UpdatePlayerCount(true);
            playerRenderer.material.color = clear;
        }
    }

    private void UpdatePlayerCount(bool isGiving)
    {
        Debug.Log("UpdatePlayerCount was called");

        if(renderer.material.color == player1Material.color)
        {
            if (isGiving)
                player1Count++;
            else
                player1Count--;
        }
        else if(renderer.material.color == player2Material.color)
        {
            if (isGiving)
                player2Count++;
            else
                player2Count--;
        }
        else if(renderer.material.color == player3Material.color)
        {
            if (isGiving)
                player3Count++;
            else
                player3Count--;
        }
        else if(renderer.material.color == player4Material.color)
        {
            if (isGiving)
                player4Count++;
            else
                player4Count--;
        }
    }
}

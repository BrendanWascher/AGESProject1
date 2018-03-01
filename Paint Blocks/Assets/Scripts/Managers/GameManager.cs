using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //this class is based off of the Tank Tutorials "TankManager"
    //class in the tanks tutorial on the Unity Website

    public int numberOfRoundsToWin = 3;
    public float startDelay = 3f;
    public float endDelay = 3f;

    public CameraController cameraController;
    public Text messageText;
    public GameObject camera;
    public GameObject playerPrefab;
    public PlayerManager[] players;
    //public GameObject floor;

    private int roundNumber;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    private PlayerManager roundWinner;
    private PlayerManager gameWinner;

    void Start ()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);

        SpawnAllPlayers();
        SetCameraTargets();

        StartCoroutine(GameLoop());
	}

    private void SpawnAllPlayers()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].playerInstance =
                Instantiate(playerPrefab, players[i].playerSpawnPoint.position,
                players[i].playerSpawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].camera = camera;
            players[i].Setup();
        }
    }

    private void SetCameraTargets()
    {
        Transform[] targets = new Transform[players.Length];

        for(int i = 0; i < targets.Length; i++)
        {
            targets[i] = players[i].playerInstance.transform;
        }

        cameraController.targets = targets;
    }

    
    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if(gameWinner != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }
    

    private IEnumerator RoundStarting()
    {
        ResetAllPlayers();
        DisablePlayerControl();

        cameraController.SetStartPositionAndSize();
        roundNumber++;
        messageText.text = "Round " + roundNumber;

        yield return startWait;
    }

    private IEnumerator RoundPlaying()
    {
        EnablePlayerControl();

        messageText.text = string.Empty;

        while(!TimeIsUp())
        {
            yield return null;
        }
    }

    private IEnumerator RoundEnding()
    {
        DisablePlayerControl();

        roundWinner = null;

        roundWinner = GetRoundWinner();

        if(roundWinner != null)
        {
            roundWinner.numberOfWins++;
        }

        GameTimer.startTimer = startDelay + endDelay;

        gameWinner = GetGameWinner();

        string message = EndMessage();
        messageText.text = message;

        yield return endWait;
    }

    private bool TimeIsUp()
    {
        return GameTimer.isTimeUp;
    }

    private PlayerManager GetRoundWinner()
    {
        for(int i = 0; i < players.Length; i++)
        {
            if (players[i].numberOfWins == numberOfRoundsToWin)
                return players[i];
        }

        return null;
    }

    private PlayerManager GetGameWinner()
    {
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].numberOfWins == numberOfRoundsToWin)
            {
                return players[i];
            }
        }

        return null;
    }

    private string EndMessage()
    {
        string message = "DRAW!";

        if(roundWinner != null)
        {
            message = roundWinner.coloredPlayerText + " wins the round!";
        }

        message += "\n\n\n\n";

        for(int i = 0; i < players.Length; i++)
        {
            message += players[i].coloredPlayerText + " has " +
                players[i].numberOfWins + " wins.";
        }

        if(gameWinner != null)
        {
            message = gameWinner.coloredPlayerText + " has won the game!";
        }

        return message;
    }

    private void ResetAllPlayers()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].Reset();
        }
    }

    private void EnablePlayerControl()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].EnableControl();
        }
    }

    private void DisablePlayerControl()
    {
        for(int i = 0; i < players.Length; i++)
        {
            players[i].DisableControl();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //this class is based off of the Tank Tutorials "TankManager"
    //class in the tanks tutorial on the Unity Website

    public int numberOfRoundsToWin = 3;
    public float startDelay = 3f;
    public float endDelay = 3f;

    public CameraController cameraController;
    public GameObject camera;
    public GameObject playerPrefab;
    public PlayerManager[] players;

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

        //StartCoroutine(GameLoop());
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

    /*
    private IEnumerator GameLoop()
    {
        //yield return StartCoroutine(RoundStarting());
        //yield return StartCoroutine(RoundPlaying());
        //yield return StartCoroutine(RoundEnding());

        if(gameWinner != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }
    */

    private IEnumerator RoundStarting()
    {
        throw new NotImplementedException();
    }

    private IEnumerator RoundPlaying()
    {
        throw new NotImplementedException();
    }

    private IEnumerator RoundEnding()
    {
        throw new NotImplementedException();
    }
}

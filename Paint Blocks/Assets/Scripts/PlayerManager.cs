using System;
using UnityEngine;

[Serializable]
public class PlayerManager
{
    //this class is based off of the Tank Tutorials "TankManager"
    //class in the tanks tutorial on the Unity Website

    public Material playerMaterial;
    public Transform playerSpawnPoint;
    public GameObject camera;
    [HideInInspector] public int playerNumber;
    [HideInInspector] public GameObject playerInstance;
    [HideInInspector] public int numberOfWins;

    private PlayerController playerController;
    private GameObject canvasGameObject;

    public void Setup()
    {
        playerController = playerInstance.GetComponent<PlayerController>();
        canvasGameObject = playerInstance.GetComponentInChildren<Canvas>().gameObject;

        playerController.playerNumber = playerNumber;
        playerController.playerMaterial = playerMaterial;
        playerController.camera = camera;

        MeshRenderer[] renderers = playerInstance.GetComponentsInChildren<MeshRenderer>();

        for(int i = 0; i < renderers.Length; i++)
        {
            renderers[i].material = playerMaterial;
        }
    }

    public void DisableControl()
    {
        playerController.enabled = false;

        canvasGameObject.SetActive(false);
    }

    public void EnableControl()
    {
        playerController.enabled = true;

        canvasGameObject.SetActive(true);
    }

    public void Reset()
    {
        playerInstance.transform.position = playerSpawnPoint.position;
        playerInstance.transform.rotation = playerSpawnPoint.rotation;

        playerInstance.SetActive(false);
        playerInstance.SetActive(true);
    }
}

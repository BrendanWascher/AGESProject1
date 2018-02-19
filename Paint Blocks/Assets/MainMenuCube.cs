using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuCube : MonoBehaviour
{

    public void RotateToAudioPanel(bool isTo)
    {
        if (isTo)
        {
            this.gameObject.transform.Rotate(0f, 90f, 0f);
        }
        else
            this.gameObject.transform.Rotate(0f, -90f, 0f);
    }
}

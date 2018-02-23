using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLookAtCamera : MonoBehaviour
{
    [SerializeField]
    Transform camera;

    void FixedUpdate ()
    {
        LookAtCamera();
	}

    // seperate function in case other code needs to be added so not to
    // clog up fixedupdate
    private void LookAtCamera()
    {
        transform.LookAt(camera);
        transform.Rotate(0, 180f, 0);
    }
}

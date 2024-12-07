using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFaceToCamera : MonoBehaviour
{
    private Camera mainCamera;
    void Update()
    {
        mainCamera = Camera.main;
        transform.LookAt(mainCamera.transform);
    }
}

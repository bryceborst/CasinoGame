using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private String cameraMode;

    [SerializeField] private int sensitivity;

    //[SerializeField] private InputManager controllerInput;

    private float rotation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (cameraMode.Equals("MainCameraMode"))
        {
          //  MainCameraMode(Time.deltaTime);
        }
    }

    /*
    private void MainCameraMode(float deltaTime)
    {
        // float mouseX = input.Look.x * sensitivity * deltaTime;
       // float mouseY = input.Look.y * sensitivity * deltaTime;
        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90, 90);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        playerParent.Rotate(Vector3.up, mouseX);
    }
    */
}

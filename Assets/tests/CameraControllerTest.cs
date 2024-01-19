using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerTest : MonoBehaviour
{
    [SerializeField] private String cameraMode;

    [SerializeField] private Transform playerParent;

    [SerializeField] private int sensitivity;

    private CameraTestControls input;

    private Vector2 look;

    private float rotation;
    
    
    // Start is called before the first frame update
    void Start()
    {
        input = new CameraTestControls();
        input.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        look = input.CameraTest.Look.ReadValue<Vector2>();
        Debug.Log(look.x + " " + look.y);
        if (cameraMode.Equals("MainCameraMode"))
        {
            MainCameraMode(Time.deltaTime);
        }
    }

    private void MainCameraMode(float deltaTime)
    {
        float mouseX = look.x * sensitivity * deltaTime;
        float mouseY = look.y * sensitivity * deltaTime;
        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90, 90);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        playerParent.Rotate(Vector3.up, mouseX);
    }
}
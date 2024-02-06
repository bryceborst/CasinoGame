using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class CameraControllerTest : MonoBehaviour
{
    [SerializeField] private String cameraMode;

    [SerializeField] private Transform playerParent;

    [SerializeField] private int xSensitivity;
    
    [SerializeField] private int ySensitivity;

    private InputManager input;

    private Controls controls;

    //private Vector2 look;

    private float rotation;

    private UnityEngine.Vector2 look;
    
    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
        controls = new Controls();
        controls.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        look = input.Look;

        if (cameraMode.Equals("MainCameraMode"))
        {
            MainCameraMode(Time.deltaTime);
        }
    }

    private void MainCameraMode(float deltaTime)
    {
        float mouseX = look.x * xSensitivity * deltaTime;
        float mouseY = look.y * ySensitivity * deltaTime;
        rotation -= mouseY;
        rotation = Mathf.Clamp(rotation, -90, 90);
        transform.localRotation = Quaternion.Euler(rotation, 0, 0);
        playerParent.Rotate(Vector3.up, mouseX);
    }
}
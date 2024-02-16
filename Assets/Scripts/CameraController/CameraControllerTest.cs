using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControllerTest : MonoBehaviour
{
    [SerializeField] private String cameraMode;

    [SerializeField] private Transform playerParent;

    [SerializeField] private int xSensitivity;

    [SerializeField] private int ySensitivity;

    private InputManager input;

    private Vector2 look;

    private float rotation;

    [SerializeField] private Transform subCameraPosition;
    
    
    // Start is called before the first frame update
    void Start()
    {
        input = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        look = input.Look;
        if (cameraMode.Equals("MainCameraMode"))
        {
            transform.position = playerParent.position + new Vector3(0,.75f,0);
            MainCameraMode(Time.deltaTime);
        }
        else if (cameraMode.Equals("SubCameraMode"))
        {
            SubCameraMode(subCameraPosition);
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

    private void SubCameraMode(Transform position)
    {
        transform.position = position.position;
        transform.rotation = position.rotation;
    }

    public void setCameraMode(int mode)
    {
        if (mode == 1)
        {
            cameraMode = "MainCameraMode";
        }

        if (mode == 2)
        {
            cameraMode = "SubCameraMode";
        }
    }
    
}
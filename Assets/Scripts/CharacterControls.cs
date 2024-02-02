using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class CharacterControls : MonoBehaviour
{
    private InputManager inputManager;
    
    private CharacterController _controller;
    private float runSpeed = 5.5f;
    private float sprintSpeed = 8f;
    private bool isSprinting = false;
    private float stamina = 100f;
    private Rigidbody rigid;
    private bool inTriggerZone;
    [SerializeField] private TMP_Text hText;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        _controller = GetComponent<CharacterController>();

        inputManager.Sprint.performed += context => isSprinting = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement(Time.deltaTime);
        if (inTriggerZone)
        {
            handleTriggerZone();
        }
    }
    
    private void HandleMovement(float delta)
    {
        Vector3 movement = (inputManager.Move.x * transform.right) + (inputManager.Move.y * transform.forward);
    
        _controller.Move( runSpeed * movement * delta);
        
        if (isSprinting)
        {
            stamina -= Time.deltaTime * 10;
            _controller.Move(sprintSpeed * movement * delta);
        }

    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("LookTrigger"))
        {
            inTriggerZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inTriggerZone = false;
        GetComponentInChildren<CameraControllerTest>().setCameraMode(1);
        hText.SetText(" ");
    }

    private void handleTriggerZone()
    {
        
        hText.SetText("Press H to view");
        if (inputManager.H.ReadValue<float>() == 1f)
        {
            hText.SetText(" ");
                   GetComponentInChildren<CameraControllerTest>().setCameraMode(2);
                   inTriggerZone = false;
        }
    }

    private bool IsGrounded()
    {
        return _controller.isGrounded;
    }
}

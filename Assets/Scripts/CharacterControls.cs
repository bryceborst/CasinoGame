using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterControls : MonoBehaviour
{
    private InputManager inputManager;
    
    private CharacterController _controller;
    private float runSpeed = 5.5f;
    private float sprintSpeed = 8f;
    private bool isSprinting = false;
    private float stamina = 100f;

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
    

    private bool IsGrounded()
    {
        return _controller.isGrounded;
    }
}

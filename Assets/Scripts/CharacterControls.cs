using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControls : MonoBehaviour
{
    private InputManager inputManager;
    
    private CharacterController _controller;
    private float runSpeed = 7.5f;
    private float sprintSpeed = 12;
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        _controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleMovement(Time.deltaTime);
        HandleSprint(Time.deltaTime);
    }
    
    private void HandleMovement(float delta)
    {
        Vector3 movement = (inputManager.Move.x * transform.right) + (inputManager.Move.y * transform.forward);
    
        _controller.Move( runSpeed * movement * delta);

    }

    private void HandleSprint(float delta)
    {
        Vector2 movement = (inputManager.Move.x * transform.right) + (inputManager.Move.y * transform.forward);

        _controller.Move(sprintSpeed * movement * delta);
    }

    private bool IsGrounded()
    {
        return _controller.isGrounded;
    }
}

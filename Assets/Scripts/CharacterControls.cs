using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    private InputManager inputManager;

//Movement vars
    private CharacterController _controller;
    [SerializeField] private float runSpeed = 9f;
    [SerializeField] private float sprintSpeed = 15f;
    private bool isSprinting = false;
    private bool _cancelSprint = false;
    private bool _wPressed = false;
    
    //Stamina vars
    [SerializeField] private float _staminaGainRate = 7f;
    [SerializeField] private float staminaLossRate = 10f;
    private bool _noStamina = false;
    [SerializeField] public Slider _slider;
    private float stamina = 100f;
    
    //Interacting vars
    private Rigidbody rigid;
    private bool inTriggerZone;
    [SerializeField] private TMP_Text hText;
    private bool lookingAtSomething;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        _controller = GetComponent<CharacterController>();
        
        lookingAtSomething = false;
        
        //Slider setup
        _slider.minValue = 0f;
        _slider.maxValue = 100f;

        inputManager.Sprint.performed += context => isSprinting = true;
        inputManager.Sprint.canceled += context => isSprinting = false;
        
        inputManager.WDown.performed += context => _wPressed = true;
        inputManager.WDown.canceled += context => _wPressed = false;
        
        _wPressed = inputManager.ForwardCheck;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!lookingAtSomething)
        {
            HandleMovement(Time.deltaTime);            
        }
        else
        {
            handLookingAtSomething();
        }
        if (inTriggerZone)
        {
            handleTriggerZone();
        }
        HandleStamina();
    }
    
    private void HandleMovement(float delta)
    {
        //Walk speed
        Vector3 movement = (inputManager.Move.x * transform.right) + (inputManager.Move.y * transform.forward);

        _controller.Move(runSpeed * movement * delta);

        //"W" must be pressed or sprint gets cancelled
        if (!_wPressed)
        {
            _cancelSprint = true;
        }
        else
        {
            _cancelSprint = false;
        }


        //Cleans up sprinting so you can only sprint forward and "diagonal forward"
        if (isSprinting && !_cancelSprint)
        {
            //Use for future stamina feature
            if (stamina > 0 && !_noStamina)
            {
                stamina -= Time.deltaTime * staminaLossRate;
                //Moves player at sprint speed
                _controller.Move(sprintSpeed * movement * delta);
            }
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

    public void handleH()
    {
        if (inTriggerZone)
        {
            handLookingAtSomething();
        }

        else if (lookingAtSomething)
        {
            lookAway();
        }
    }

    private void handLookingAtSomething()
    {
        
        hText.SetText("Press H to exit");
        GetComponentInChildren<CameraControllerTest>().setCameraMode(2);
        inTriggerZone = false;
        lookingAtSomething = true;
        
    }

    private void lookAway()
    {
        GetComponentInChildren<CameraControllerTest>().setCameraMode(1);
        hText.SetText(" ");
        lookingAtSomething = false;
    }

    private void handleTriggerZone()
    {
        hText.SetText("Press H to view");
    }
    
    private void HandleStamina()
    {

        //Checks left shift, reasonable stamina, and the 0 stamina delay
        if (!isSprinting && stamina < 100 && stamina > 0 && !_noStamina)
        {
            stamina += Time.deltaTime * _staminaGainRate;
        }
        //When stamina runs all the way out it flicks a switch that keeps stamina "turned off" until it regens to 50
        else if (stamina <= 0 || _noStamina)
        {
            //HIT ZERO
            _noStamina = true;
            _cancelSprint = true;
            if (isSprinting)
            {
                //DO LATER
                //print message on screen that reads "Stop sprinting to regain stamina"
            }
            else if (stamina <= 50 && !isSprinting)
            {
                stamina += Time.deltaTime * _staminaGainRate;
            }
            else if (stamina > 50)
            {
                _noStamina = false;
            }
        }

        stamina = stamina switch
        {
            > 100f => 100,
            < 0f => 0f,
            _ => stamina
        };
        _slider.value = stamina;

    }

    private bool IsGrounded()
    {
        return _controller.isGrounded;
    }
}

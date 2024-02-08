using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CharacterControls : MonoBehaviour
{
    public Slider _slider;

    private InputManager _inputManager;

    private Controls _controls;

    private CharacterController _controller;

    [FormerlySerializedAs("runSpeed")] [SerializeField]
    private float _walkSpeed = 5.5f;

    [SerializeField] private float sprintSpeed = 8f;

    private bool _isSprinting = false;

    private bool _cancelSprint = false;

    private float _stamina = 100f;

    [SerializeField] private float _staminaGainRate;

    private bool _noStamina = false;

    private bool _wPressed = false;

    [SerializeField] private float staminaLossRate = 10f;


    // Start is called before the first frame update
    void Start()
    {
        _inputManager = InputManager.instance;
        _controller = GetComponent<CharacterController>();

        //Slider setup
        //_slider = GetComponent<Slider>();
        //_slider.enabled = true;
        _slider.minValue = 0f;
        _slider.maxValue = 100f;

        _inputManager.Sprint.performed += context => _isSprinting = true;
        _inputManager.Sprint.canceled += context => _isSprinting = false;

        _inputManager.ForwardCheck.performed += context => _wPressed = true;
        _inputManager.ForwardCheck.canceled += context => _wPressed = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleStamina();
        HandleMovement(Time.deltaTime);
    }

    private void HandleMovement(float delta)
    {
        //Walk speed
        Vector3 movement = (_inputManager.Move.x * transform.right) + (_inputManager.Move.y * transform.forward);

        _controller.Move(_walkSpeed * movement * delta);

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
        if (_isSprinting && !_cancelSprint)
        {
            //Use for future stamina feature
            if (_stamina > 0 && !_noStamina)
            {
                _stamina -= Time.deltaTime * staminaLossRate;
                //Moves player at sprint speed
                _controller.Move(sprintSpeed * movement * delta);
            }
        }
    }

    private void HandleStamina()
    {

        //Checks left shift, reasonable stamina, and the 0 stamina delay
        if (!_isSprinting && _stamina < 100 && _stamina > 0 && !_noStamina)
        {
            _stamina += Time.deltaTime * _staminaGainRate;
        }
        //When stamina runs all the way out it flicks a switch that keeps stamina "turned off" until it regens to 50
        else if (_stamina <= 0 || _noStamina)
        {
            //HIT ZERO
            _noStamina = true;
            _cancelSprint = true;
            if (_isSprinting)
            {
                //DO LATER
                //print message on screen that reads "Stop sprinting to regain stamina"
            }
            else if (_stamina <= 50 && !_isSprinting)
            {
                _stamina += Time.deltaTime * _staminaGainRate;
            }
            else if (_stamina > 50)
            {
                _noStamina = false;
            }
        }

        _stamina = _stamina switch
        {
            > 100f => 100,
            < 0f => 0f,
            _ => _stamina
        };
        _slider.value = _stamina;

    }






}

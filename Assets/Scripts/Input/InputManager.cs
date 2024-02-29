using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class InputManager : MonoBehaviour
{
    
    public static InputManager instance;

    private Controls controls;

    [SerializeField] private CharacterControls _characterControls;
    public Vector2 Move { get; private set; }
    
    public Vector2 Look { get; private set; }
    
    public bool Flashlight { get; private set; }

    public bool ForwardCheck { get; private set; }

    public InputAction Interact;


    public InputAction Sprint;
    public InputAction WDown;

    private InputAction H;

    private float PreviousH;
    
    public void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        
        controls = new Controls();
        controls.Enable();
    }
    // Start is called before the first frame update
    void Start()
    {
        Sprint = controls.Locomotion.Sprint;
        WDown = controls.Locomotion.ForwardCheck;
        Interact = controls.Locomotion.Interact;
        
        H = controls.Locomotion.TriggerButton;
    }

    // Update is called once per frame
    void Update()
    {
        Move = controls.Locomotion.Move.ReadValue<Vector2>();
        
        //USE LATER
        Look = controls.Locomotion.Look.ReadValue<Vector2>();

        Flashlight = controls.Locomotion.Flashlight.IsPressed();

        if (H.ReadValue<float>() > PreviousH)
        {
            _characterControls.handleH();
        }
        PreviousH = H.ReadValue<float>();

    }
    
}

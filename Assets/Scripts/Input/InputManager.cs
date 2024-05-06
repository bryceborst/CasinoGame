using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class InputManager : MonoBehaviour
{
    
    public static InputManager instance;

    private Controls controls;

    private bool movementOn = true;

    [SerializeField] private CharacterControls _characterControls;
    public Vector2 Move { get; private set; }
    
    public Vector2 Look { get; private set; }
    
    public bool Flashlight { get; private set; }

    public bool ForwardCheck { get; private set; }

    public InputAction Interact;

    public InputAction Drop;
    
    public InputAction HotbarSlot1;
    public InputAction HotbarSlot2;
    public InputAction HotbarSlot3;
    public InputAction HotbarSlot4;
    public InputAction HotbarSlot5;


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
        
        HotbarSlot1 = controls.Locomotion.Slot1;
        HotbarSlot2 = controls.Locomotion.Slot2;
        HotbarSlot3 = controls.Locomotion.Slot3;
        HotbarSlot4 = controls.Locomotion.Slot4;
        HotbarSlot5 = controls.Locomotion.Slot5;
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Sprint = controls.Locomotion.Sprint;
        WDown = controls.Locomotion.ForwardCheck;
        Interact = controls.Locomotion.Interact;
        Drop = controls.Locomotion.DropItem;
        
     
        
        H = controls.Locomotion.TriggerButton;

    }

    // Update is called once per frame
    void Update()
    {
        if (movementOn)
        {
           Move = controls.Locomotion.Move.ReadValue<Vector2>();
            
           Look = controls.Locomotion.Look.ReadValue<Vector2>();            
        }

        Flashlight = controls.Locomotion.Flashlight.IsPressed();

        if (H.ReadValue<float>() > PreviousH)
        {
            _characterControls.handleH();
        }
        PreviousH = H.ReadValue<float>();
        

    }

    public void disableMovement()
    {
        movementOn = false;
        Move = new Vector2(0, 0);
        Look = new Vector2(0, 0);
    }

    public void enableMovement()
    {
        movementOn = true;
    }
    
}

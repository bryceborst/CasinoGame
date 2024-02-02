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
    
    
    public Vector2 Move { get; private set; }
    
    public Vector2 Look { get; private set; }


    public InputAction Sprint;

    public InputAction H;
    
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
        
        H = controls.Locomotion.TriggerButton;
    }

    // Update is called once per frame
    void Update()
    {
        Move = controls.Locomotion.Move.ReadValue<Vector2>();
        
        //USE LATER
        Look = controls.Locomotion.Look.ReadValue<Vector2>();
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    
    public static InputManager instance;

    private Controls controls;

    private bool isPressed;
    
    public Vector2 Move { get; private set; }
    
    //public Vector2 Look { get; private set; }
    
    public Vector2 Sprint { get; private set; }
    
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
        
    }

    // Update is called once per frame
    void Update()
    {
        Sprint = controls.Locomotion.Sprint.ReadValue<Vector2>();
        Move = controls.Locomotion.Move.ReadValue<Vector2>();
        
        //USE LATER
        //Look = controls.Locomotion.Look.ReadValue<Vector2>(); 
    }

    private void SprintPressed()
    {
        if (controls.Locomotion.Sprint.ReadValue<Vector2>() != Vector2.zero)
        {
            isPressed = true;
        }
        else
        {
            isPressed = false;
        }
        
    }
}

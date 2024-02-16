using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class FlashlightController : MonoBehaviour
{
    [SerializeField]
    public float flashlightRange = 10f;
    
    public Light flashlight;

    public InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleFlashlight();
        
    }

    private void HandleFlashlight()
    {
        switch (inputManager.Flashlight)
        {
            case true:
                //if f is pressed and light is on, turn off.
                //else turn on
                flashlight.enabled = true;
                break;
            
            case false:
                flashlight.enabled = false;
                break;
        }








        
        
    }
    
    
    
    
    
    
    
}

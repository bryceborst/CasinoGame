using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleLights : MonoBehaviour, IInteractable
{

    [SerializeField] public HandleLights lights;

    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        //lights = GetComponent<HandleLights>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void Interact()
    {
        
        Debug.Log("INTERACTED");
        
        /*
        switch (isOn)
        {
            case true:
                isOn = false;
                lights.enabled = false;
                break;
            
            case false:
                isOn = true;
                lights.enabled = true;
                break;
        }
        */
    }
}

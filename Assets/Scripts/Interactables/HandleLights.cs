using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;

public class HandleLights : MonoBehaviour, IInteractable
{

    private List<Light> lights;

    private bool isOn = true;

    // Start is called before the first frame update
    void Start()
    {
        lights = new List<Light>();
        
        GameObject[] objectArray= GameObject.FindGameObjectsWithTag("Lighting");

        if (objectArray != null)
        {
            foreach (GameObject obj in objectArray)
            {
                Light l = obj.GetComponent<Light>();
                lights.Add(l);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {


        switch (isOn)
        {
            //turn all lights on
            case true:
                foreach (Light light in lights)
                {
                    light.enabled = true;
                }
                break;
            
            
            
            //turn all lights off
            case false:
                foreach (Light light in lights)
                {
                    light.enabled = false;
                }
                break;
        }
    }

    public void Interact()
    {
        Debug.Log("INTERACTED");
        
        if (isOn)
        {
            isOn = false;
        }
        else
        {
            isOn = true;
        }
        
    }
}

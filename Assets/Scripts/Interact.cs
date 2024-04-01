using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Interact : MonoBehaviour
{

    private bool eDown;

    private bool switchBool = false;

    private InputManager inputManager;

    private float raidius = 2;

    [SerializeField] public Camera mainCamera;

    [SerializeField] public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;
        inputManager.Interact.performed += context => switchBool = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        switch (switchBool)
        {
            case true:
                eDown = true;
                switchBool = false;
                break;
            
            default:
                eDown = false;
                break;
        } 
        
        CheckForInteractable();

    }

    private void CheckForInteractable()
    {
        // constantly raycast
        // if the raycast hits something that is interactable
        // show popup
        // otherwise do nothing
        
        RaycastHit hit;
        if (Physics.SphereCast(mainCamera.transform.position, raidius, mainCamera.transform.forward, out hit, 3f))
        {
            var interactingObject = hit.transform.GetComponent<IInteractable>();
            
            if (interactingObject != null && eDown)
            {
                interactingObject.Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        var cam = mainCamera.transform;
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(cam.position + cam.forward * 3f, 2);
    }

    public void extendRaidius(float extension)
    {
        raidius += extension;
    }

}

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

    [SerializeField] public Camera mainCamera;

    [SerializeField] public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;




    }

    // Update is called once per frame
    void Update()
    {

        inputManager.Interact.performed += context => switchBool = true;
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
        if (Physics.SphereCast(player.position, 2, mainCamera.transform.rotation.eulerAngles, out hit, 3f))
        {
            if (hit.transform.GetComponent<IInteractable>() != null && eDown)
            {
                hit.transform.GetComponent<IInteractable>().Interact();
            }
        }
    }

    private void OnDrawGizmos()
    {
        var cam = mainCamera.transform;
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(cam.position + cam.forward * 3f, 2);
    }
}

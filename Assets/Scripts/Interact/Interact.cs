using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;
using UnityEngine.Serialization;

public class Interact : MonoBehaviour
{
    [SerializeField] private TMP_Text hotbarText;

    [SerializeField] public HandleKey handleKey;
    
    private bool isHotbarItem = false;
    
    private bool eDown;

    private bool switchBool = false;

    private InputManager inputManager;

    [SerializeField] public Camera mainCamera;

    [SerializeField] public Transform player;

    [SerializeField] private HotbarController _hotbarController;
    
    
    
    // field that stores whatever you are looking
    private GameObject interactingObject;
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;

        inputManager.Interact.performed += context => AttemptInteract();
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        //Debug.Log(this.name);
        // constantly raycast
        // if the raycast hits something that is interactable
        // show popup
        // otherwise do nothing
        
        RaycastHit hit;
        if (Physics.SphereCast(mainCamera.transform.position, 2, mainCamera.transform.forward, out hit, 3f))
        {
            

            var inter = hit.transform.GetComponent<IInteractable>();
            
            if (inter != null)
            {
                interactingObject = hit.transform.gameObject;
                return;
            }
            
            var item = hit.transform.GetComponent<IHotbar>();

            
            if (item != null && !handleKey.runTimer)
            {
                hotbarText.text = ("Press E to add '" + hit.transform.name + "' to Hotbar");
                isHotbarItem = true;
            }

        }

    }

    private void AttemptInteract()
    {

        if (interactingObject == null)
        {
            return;
        }
        
        var inter = interactingObject.GetComponent<IInteractable>();
        var hotbarItem = interactingObject.GetComponent<IHotbar>();

        Debug.Log(interactingObject.name);

        inter.Interact();
            
            
        if (hotbarItem != null)
        {
            Debug.Log("Checking if the item is null");
            _hotbarController.AddToHotbar(interactingObject);
            hotbarItem.Add();
        }
            
    }
    
    private void OnDrawGizmos()
    {
        var cam = mainCamera.transform;
        Gizmos.color = Color.magenta;
        //Gizmos.DrawSphere(cam.position, 2);
        Gizmos.DrawRay(cam.position, cam.forward * 3);
    }
    
}




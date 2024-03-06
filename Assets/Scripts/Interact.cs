using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Interact : MonoBehaviour
{

    private bool eDown;

    private InputManager inputManager;

    [SerializeField] public Camera mainCamera;

    [SerializeField] public Transform player;
    
    // Start is called before the first frame update
    void Start()
    {
        inputManager = InputManager.instance;



        inputManager.Interact.performed += context => eDown = true;
        inputManager.Interact.canceled += context => eDown = false;

    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
    }

    private void CheckForInteractable()
    {
        // constantly raycast
        // if the raycast hits something that is interactable
        // show popup
        // otherwise do nothing
        RaycastHit hit;

        if (Physics.SphereCast(player.position, 3, mainCamera.transform.rotation.eulerAngles, out hit, 5f))
        {
            Debug.Log(hit);
            if (hit.transform.GetComponent<IInteractable>() != null && eDown)
            {
                hit.transform.GetComponent<IInteractable>().Interact();
            }
        }

    }
}

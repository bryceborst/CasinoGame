using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{

    private bool eDown;

    private InputManager inputManager;

    public Camera mainCamera;
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
        
    }
}

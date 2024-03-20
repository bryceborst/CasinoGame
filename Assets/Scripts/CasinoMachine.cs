using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoMachine : MonoBehaviour, IInteractable
{

    private CasinoMachine machine;

    private bool isBeingLookedAt;

    [SerializeField] private CameraControllerTest _camera;

    [SerializeField] private InputManager _inputManager;
    
    // Start is called before the first frame update
    void Start()
    {
        isBeingLookedAt = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        if (!isBeingLookedAt)
        {
            _camera.setCameraMode(2);
            _inputManager.disableMovement();
            isBeingLookedAt = true;
        }
        else
        {
            _camera.setCameraMode(1);
            _inputManager.enableMovement();
            isBeingLookedAt = false;
        }

    }
}

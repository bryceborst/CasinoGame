using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenController : MonoBehaviour, IInteractable
{
    [SerializeField] private CameraControllerTest Camera;

    [SerializeField] private Interact _interact;

    private InputManager _inputManager;
    // Start is called before the first frame update
    void Start()
    {
        _inputManager = InputManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        Camera.setCameraMode(1);
        _interact.extendRaidius(-30);
        _inputManager.enableMovement();
    }
}

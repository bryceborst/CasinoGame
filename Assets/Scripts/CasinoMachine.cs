using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoMachine : MonoBehaviour, IInteractable
{

    private CasinoMachine machine;

    private bool isBeingLookedAt;

    private bool eDown;

    [SerializeField] private Interact _interact;

    [SerializeField] private CameraControllerTest _camera;

    [SerializeField] private InputManager _inputManager;

    [SerializeField] private ScreenManager _screenManager;

    [SerializeField] private int sceneToLoad;
    
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
            _camera.setCameraMode(2);
            _inputManager.disableMovement();
            _interact.extendRaidius(30);
            _screenManager.loadSenario(sceneToLoad);
    }
    
}

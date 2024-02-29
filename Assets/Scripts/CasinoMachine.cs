using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasinoMachine : MonoBehaviour, IInteractable
{

    private CasinoMachine machine;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        machine = GetComponent<CasinoMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact()
    {
        machine.transform.position += new Vector3(.1f, 0, 0);
    }
}

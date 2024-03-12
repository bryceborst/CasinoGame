using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DoorHandler : MonoBehaviour, IInteractable
{
    private float degreesOpen;

    [SerializeField] private float closedPos;

    [SerializeField] private float openPos;

    [SerializeField] private float rotSpeed;

    [SerializeField] private bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOpen)
        {
            open();
        }
        else
        {
            close();
        }
    }

    private void open()
    {
        if (degreesOpen < openPos)
        {
            degreesOpen += rotSpeed;
            transform.Rotate(new Vector3(0,1,0) * rotSpeed);
        }
    }

    private void close()
    {
        if (degreesOpen >= closedPos)
        {
            degreesOpen -= rotSpeed;
            transform.Rotate(new Vector3(0, -1, 0) * rotSpeed);
        }
    }

    public void Interact()
    {
        Debug.Log("INTERACTED");
        if (isOpen)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
    }
}

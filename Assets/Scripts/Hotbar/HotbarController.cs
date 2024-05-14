using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class HotbarController : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Image[] Slots;
    
    [SerializeField] private Transform slotParent;

    [SerializeField] private HandleImage handleImage;
    
    public GameObject[] hotbarObjects = new GameObject[5];

    private int currentSlot = 1;

    private InputManager inputManager;
    


    // Start is called before the first frame update
    void Start()
    {
        Slots = slotParent.GetComponentsInChildren<Image>();

        hotbarObjects = new GameObject[] {null, null, null, null, null};

            inputManager = InputManager.instance;

            inputManager.HotbarSlot1.performed += context =>
        {
            currentSlot = 0;
            SlotSelector();
        };
        
        inputManager.HotbarSlot2.performed += context =>
        {
            currentSlot = 1;
            SlotSelector();
        };
        inputManager.HotbarSlot3.performed += context =>
        {
            currentSlot = 2;
            SlotSelector();
        };
        inputManager.HotbarSlot4.performed += context =>
        {
            currentSlot = 3;
            SlotSelector();
        };
        inputManager.HotbarSlot5.performed += context =>
        {
            currentSlot = 4;
            SlotSelector();
        };

        inputManager.Drop.performed += context =>
        {
            Debug.Log("Drop Performed");
            RemoveFromHotbar();
        };
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddToHotbar(GameObject hotbar)
    {
        int i;

        //cycles through hotbar list searching for an empty slot and calls the add method in IHotbar

        if (hotbar.GetComponent<IHotbar>() != null)
        {
            var iHotbarComponent = hotbar.GetComponent<IHotbar>();

            for (i = 0; i < hotbarObjects.Length; i++)
            {
                Debug.Log("Ran");
                if (hotbarObjects[i] == null)
                {
                    iHotbarComponent.Add();

                    //var mesh = hotbar.GetComponent<MeshRenderer>();
                    //mesh.enabled = false;
                    hotbarObjects[i] = hotbar;
                    
                    Debug.Log("Image name: " + iHotbarComponent.Name);
                    handleImage.ImageToSlot(iHotbarComponent.Name, iHotbarComponent);
                    
                    hotbar.GetComponent<MeshRenderer>().enabled = false;
                    hotbar.GetComponent<Collider>().enabled = false;
                    Debug.Log("AddToHotbar Complete");
                    break;
                }
            }
            

        }
    }

    private void SlotSelector()
    {
        //Set the selected slot - set to high opacity white & for every other slot - set to white default opacity.

        for (int i = 0; i < Slots.Length; i++)
        {
            if (i == (currentSlot))
            {
                Slots[i].color = new Color(67,206,241, 1f);
                continue;
            }
            Slots[i].color = new Color(255, 255, 255, .39215f);
        }

    }
    
    public void RemoveFromHotbar()
    {
        //If there is an item in slot, enable and move item in front of player, remove item from image and item arrays
        //make item IHotbar to reference Remove() method.

        
        
        if (hotbarObjects[currentSlot] != null)
        {
            hotbarObjects[currentSlot].GetComponent<MeshRenderer>().enabled = true;
            hotbarObjects[currentSlot].GetComponent<BoxCollider>().enabled = true;
            hotbarObjects[currentSlot].transform.position = player.transform.position + new Vector3(0, -1, 1);


            var hotbarItem = hotbarObjects[currentSlot].GetComponent<IHotbar>();
            hotbarItem.Remove();
            hotbarObjects[currentSlot] = null;


            
        }
        else
        {
            Debug.Log("Item Drop Failed \n" +
                      "No Item Available to Drop. ");
        }
    }



    
    
}

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
    
    private bool dropped = false;


    // Start is called before the first frame update
    void Start()
    {
        Slots = slotParent.GetComponentsInChildren<Image>();

        hotbarObjects = new GameObject[] {null, null, null, null, null};

            inputManager = InputManager.instance;
        inputManager.Drop.performed += context => dropped = true;

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

        inputManager.Drop.performed += context => RemoveFromHotbar();
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
        //If there is an item in slot, move item to character, activate item,
        //make item IHotbar to reference Remove() method.
        IHotbar hotbarItem;
        
        
        if (hotbarObjects[currentSlot] != null)
        {
            hotbarObjects[currentSlot].SetActive(true);
            hotbarObjects[currentSlot].transform.position = player.transform.position + new Vector3(0, -1, 1);


            hotbarItem = hotbarObjects[currentSlot].GetComponent<IHotbar>();
            hotbarItem.Remove();
            hotbarObjects[currentSlot] = null;



            dropped = false;
        }
        else
        {
            Debug.Log("Item Drop Failed \n" +
                      "No Item Available to Drop. ");
        }
    }



    
    
}

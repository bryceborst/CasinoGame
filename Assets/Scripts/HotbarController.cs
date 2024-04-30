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
    
    
    private GameObject[] hotbarObjects = new GameObject[5];

    private int currentSlot = 1;

    private InputManager inputManager;

    
    private bool dropped = false;


    // Start is called before the first frame update
    void Start()
    {
        Slots = slotParent.GetComponentsInChildren<Image>();
        
        
        inputManager = InputManager.instance;
        inputManager.Drop.performed += context => dropped = true;

        inputManager.HotbarSlot1.performed += context =>
        {
            currentSlot = 1;
            SlotSelector();
        };
        
        inputManager.HotbarSlot2.performed += context =>
        {
            currentSlot = 2;
            SlotSelector();
        };
        inputManager.HotbarSlot3.performed += context =>
        {
            currentSlot = 3;
            SlotSelector();
        };
        inputManager.HotbarSlot4.performed += context =>
        {
            currentSlot = 4;
            SlotSelector();
        };
        inputManager.HotbarSlot5.performed += context =>
        {
            currentSlot = 5;
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
        int i = 0;

        var iHotbarComponent = hotbar.GetComponent<IHotbar>();
        //cycles through hotbar array searching for an empty slot and calls the add method in IHotbar

        if (iHotbarComponent != null)
        {
            for (i = 0; i < hotbarObjects.Length; i++)
            {
                if (hotbarObjects[i] == null)
                {
                    iHotbarComponent.Add();

                    //var mesh = hotbar.GetComponent<MeshRenderer>();
                    //mesh.enabled = false;
                    hotbarObjects[i] = hotbar;

                    hotbar.SetActive(false);
                    break;
                }
            }
        }
        else
        {
            return;
        }
        
        
        Debug.Log("AddToHotbar Called\n" + 
                         "Adding Object: " + hotbarObjects[i]);
    }

    private void SlotSelector()
    {
        Debug.Log("Ran");
        //Set the selected slot - set to high opacity white & for every other slot - set to white default opacity.


        for (int i = 0; i < Slots.Length; i++)
        {
            if (i == (currentSlot - 1))
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

    public void ImageToSlot()
    {
        Image keyjpg = Resources.Load<Image>("Assets/Scripts/HotbarAssets/KeyJpg.jpg");
        Slots[currentSlot - 1] = keyjpg;
        


    }
    
    
}

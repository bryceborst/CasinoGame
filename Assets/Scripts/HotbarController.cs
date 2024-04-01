using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HotbarController : MonoBehaviour
{

    private IHotbar[] hotbarObjects = new IHotbar[5];

    private int currentSlot;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToHotbar(IHotbar hotbar)
    {
        bool freeSlot = false;
        int i;
        
        for (i = 0; i < hotbarObjects.Length; i++)
        {
            if (hotbarObjects[i] == null)
            {
                freeSlot = true;
                break;
            }
        }

        if (freeSlot)
        {
            hotbarObjects[i] = hotbar;
        }
        Debug.Log("AddToHotbar Called\n" + hotbarObjects[i]);
    }

    public void PickSlot()
    {



        
    }
    

    public void RemoveFromHotbar()
    {
        hotbarObjects[currentSlot] = null;
        
    }
    
    
    
}

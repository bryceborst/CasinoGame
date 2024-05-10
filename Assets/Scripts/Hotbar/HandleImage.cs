using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HandleImage : MonoBehaviour
{
    [SerializeField] private RawImage[] images;

    [SerializeField] private HotbarController hotbarController;

    [SerializeField] private HandleKey handleKey;

    [SerializeField] private Image Slot1;
    [SerializeField] private Image Slot2;
    [SerializeField] private Image Slot3;
    [SerializeField] private Image Slot4;
    [SerializeField] private Image Slot5;
    
    // Start is called before the first frame update
    void Start()
    {
        images = new RawImage[0];
        var taggedImages = GameObject.FindGameObjectsWithTag("HotbarImage");
        for (int i = 0; i < taggedImages.Length; i++)
        {
            images.Append(taggedImages[i].GetComponent<RawImage>());
        }
    }

    public void ImageToSlot(string objName, IHotbar iHotbarComponent)
    {
        RawImage image = iHotbarComponent.Image;
        if (image == null)
        {
            Debug.Log("RawImage image is null. ");
            return;
        }
        
        //find the slot with the correct object in it
        int slot = -1;

        for (int i = 0; i < hotbarController.hotbarObjects.Length; i++)
        {
            Debug.Log("HotbarObject: " + hotbarController.hotbarObjects[i].name);
            if (hotbarController.hotbarObjects[i].name == objName)
            {
                Debug.Log("Matched");
                slot = i;
                break;
            }
        }



        //Use the slot the gameObject is on to add the image on.

        if (slot == -1)
        {
            return;
        }
        

        //Move image to the active slot's position
        switch (slot)
        {
            case 0:
                image.transform.localPosition = iHotbarComponent.ImagePositions[0];
                break;
            case 1:
                image.transform.localPosition = iHotbarComponent.ImagePositions[1];
                break;
            case 2:
                image.transform.localPosition = iHotbarComponent.ImagePositions[2];
                break;
            case 3:
                image.transform.localPosition = iHotbarComponent.ImagePositions[3];
                break;
            case 4:
                image.transform.localPosition = iHotbarComponent.ImagePositions[4];
                break;
        }
        
        Debug.Log("HandleImage Completed");

        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

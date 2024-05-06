using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HandleImage : MonoBehaviour
{
    [SerializeField] private RawImage[] images;

    [SerializeField] private HotbarController hotbarController;
    // Start is called before the first frame update
    void Start()
    {
        hotbarController = GetComponent<HotbarController>();
        
        images = new RawImage[0];
        var taggedImages = GameObject.FindGameObjectsWithTag("HotbarImage");
        for (int i = 0; i < taggedImages.Length; i++)
        {
            images.Append(taggedImages[i].GetComponent<RawImage>());
        }
    }

    private void ImageToSlot()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

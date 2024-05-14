using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HandleKey : MonoBehaviour, IHotbar, IInteractable
{

    public float onScreenTime = 2f;
    public bool runTimer = false;
    [SerializeField] public TMP_Text hotbarText;

    private string _name = "Key";
    public string Name
    {
        get { return _name; }
        set { name = value; }
    }
    
    [SerializeField] private RawImage image;
    public RawImage Image
    {
        get { return image; }
        set { image = value; }
    }

    private Vector3[] positions = {new Vector3(-125,-201,0), new Vector3(-63.4f,-201,0),
        new Vector3(0,-201,0), new Vector3(60.8f, -201, 0), new Vector3(124,-201,0)};
    
    public Vector3[] ImagePositions
    {
        get { return positions; }
    }

    
    public void Interact()
    {
        hotbarText.text = "Key added to Hotbar";
        onScreenTime = 2f;
        runTimer = true;

    }

    //private HotbarController hotbarController;    DELETE LATER

    public void Add()
    {
        image.enabled = true;
        //hotbarController.ImageToSlot();
    }

    public void Remove()
    {
        image.enabled = false;
    }

    private void Awake()
    {
        image.enabled = false;
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (runTimer)
        {
            TextTimer();
        }
    }

    public void TextTimer()
    {
        onScreenTime -= Time.deltaTime;
        if (onScreenTime < 0)
        {
            hotbarText.text = "";
            runTimer = false;
            return;
        }
    }
}

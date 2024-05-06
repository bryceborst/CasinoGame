using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class HandleKey : MonoBehaviour, IHotbar, IInteractable
{

    public float onScreenTime = 2f;
    public bool runTimer = false;
    [SerializeField] public TMP_Text hotbarText;

    public void Interact()
    {
        hotbarText.text = "Key added to Hotbar";
        onScreenTime = 2f;
        runTimer = true;

    }

    private HotbarController hotbarController;

    public void Add()
    {
        //hotbarController.ImageToSlot();z
    }

    public void Remove()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        hotbarController = GetComponent<HotbarController>();
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

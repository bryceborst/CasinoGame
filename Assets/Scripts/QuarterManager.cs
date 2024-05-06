using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuarterManager : MonoBehaviour
{
    [SerializeField] private TMP_Text QuaterCounter;

    [SerializeField] private int quaters;
    // Start is called before the first frame update
    void Start()
    {
        QuaterCounter.SetText("QUARTERS:" + quaters);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void useQuater(int numUsed)
    {
        if (quaters -numUsed > 0)
        {
           quaters -= numUsed;
           QuaterCounter.SetText("QUARTERS:" + quaters);            
        }
    }
}

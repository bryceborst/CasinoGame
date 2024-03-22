using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;

    [SerializeField] private int displayedMins;

    [SerializeField] private double seconds = 1200;

    [SerializeField] private TMP_Text gameOver;

    private string displayedSeconds;

    private string displayedText;

    public bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        timer = GetComponent<TMP_Text>();
        gameOver = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Countdown();

    }

    private void Countdown()
    {
        seconds -= Time.deltaTime;
        
        //calculating display seconds
        var secs = seconds % 60;
        secs = Math.Round(secs, 2);
        
        //calculating display minutes
        displayedMins = seconds.ConvertTo<int>() / 60;

        
        //Display stuff
        if (secs < 10)
        {
            displayedSeconds = "0" + secs;
        }
        else
        {
            displayedSeconds = "" + secs;
            
        }
        //Updating UI timer

        displayedText = displayedMins + ":" + displayedSeconds;
        timer.SetText(displayedText);
        
        //Detecting game over
        if (seconds < 0)
        {
            isGameOver = true;
            gameOver.SetText("GAME OVER");
        }

    }

    public bool getGameStatus()
    {
        return isGameOver;
    }
}

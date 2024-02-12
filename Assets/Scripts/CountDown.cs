using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] private TMP_Text timer;

    [SerializeField] private int minutes;

    [SerializeField] private float seconds;

    [SerializeField] private TMP_Text gameOver;

    private string displayedSeconds;

    private bool isGameOver;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        seconds -= 0.02f;
        if (seconds < .01)
        {
            minutes -= 1;
            seconds = 59.98f;
        }

        if (minutes < 0)
        {
            isGameOver = true;
            gameOver.SetText("GAME OVER");
        }

        displayedSeconds = seconds.ToString();
        displayedSeconds.Remove(2);
        if (!isGameOver)
        {
           timer.SetText(minutes + ":" + displayedSeconds);            
        }

    }
}

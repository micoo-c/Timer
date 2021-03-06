using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;
    [SerializeField] private InputField uiInput;

    int[] timers = { 60, 5, 60, 5, 60, 30, 60, 5, 60, 5, 30 }; //default timer array
    private int i = 0;

    private string phrase;
    private float timer;
    private bool canCount = false;
    private bool doOnce = false;
    private bool thirty = false;
    private bool ten = false;
    private bool timeStop = true;


    void Start() 
    {
        timer = timers[i];
        uiText.text = timer.ToString("F");
    }

    void Update()
    {
        if (timer >= 0.0f && canCount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
            if ((timer < 30) && (thirty is true)) 
            {
                thirty = false;
                FindObjectOfType<AudioManager>().Play("thirtyseconds");
            }
            if ((timer < 10) && (ten is true))
            {
                ten = false;
                FindObjectOfType<AudioManager>().Play("tenseconds");
            }
            if ((timer < 0.8) && (timeStop is true))
            {
                timeStop = false;
                FindObjectOfType<AudioManager>().Play("stop");
            }
        }

        else if (timer <= 0.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            uiText.text = "0.00";
            timer = 0.0f;
            i += 1;
            if (i < timers.Length)
            {
                timer = timers[i];
                uiText.text = timer.ToString("F");
                CheckTimer();
                canCount = true;
                doOnce = false;
                FindObjectOfType<AudioManager>().Play("start");
            }

        }
    }

    public void ResetBtn()
    {
        i = 0;
        timer = timers[i];
        uiText.text = timer.ToString("F");
        canCount = false;
        doOnce = false;
        CheckTimer();
}

    public void PlayBtn()
    {
        canCount = true;
        FindObjectOfType<AudioManager>().Play("start");
    }

    public void PauseBtn()
    {
        canCount = false;
    }

    public void ConfirmBtn() 
    {
        phrase = uiInput.text;
        string[] words = phrase.Split(' ');
        timers = Array.ConvertAll(words, s => int.Parse(s));
        i = 0;
        timer = timers[i];
        uiText.text = timer.ToString("F");
        CheckTimer();
    }

    public void CheckTimer() //sets voice clip bools
    {
        if (timer < 10)
        {
            timeStop = true;
        }
        else if (timer < 30)
        {

            ten = true;
            timeStop = true;
        }
        else
        {
            thirty = true;
            ten = true;
            timeStop = true;
        }
    }
}

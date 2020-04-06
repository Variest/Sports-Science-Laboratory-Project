
﻿using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float intervals = 0; //how long between each boost in intensity
    public float increase = 0; //increase RPM by how many (MAYBE CHANGE TO FLAT WORK DONE?)
    public int counter = 0; //how many ten second/s have passed
    public float timer; //time between each loop
    public float elapsed; //total time elapsed
    public float limit; //entire experiment runs for X seconds

    public Stopwatch mini = new Stopwatch(); //revolves around the player's input
    public Stopwatch main = new Stopwatch(); //measures entire time, and ends the test, also at the player's input
    public Stopwatch moments = new Stopwatch(); //every ten seconds, used for loops etc. automated.

    float seconds = 5000f; //in milliseconds
    public int speedup = 1;

    public bool Begin = false; //use this when you get a button for it
    public bool resetHEAT = true;
    public bool resetCARDIO = true;
    public bool recalcCARDIO = true;
    public bool resetLUNG = true;
    public bool resetGRAPHHR = true;
    public bool resetGRAPHLUNG;

    public float FPS; //for measuring the fps ofc

    Exercise exercise;
    GraphScriptHR graph;

    // Start is called before the first frame update
    void Start()
    {
        graph = GetComponent<GraphScriptHR>();
        exercise = GetComponent<Exercise>();
        //if all the correct integers are set, then GO
        //CREATE A BUTTON FOR BEGIN ASAP

        main.Start();
        mini.Start();
        moments.Start();
    }

    // Update is called once per frame
    void Update()
    {
        Speed();
        if(mini.ElapsedMilliseconds >= (intervals*1000)) //intervals is probably measured in seconds
        {         
            mini.Restart(); //restarts the timer 
            exercise.RPM += increase;
            exercise.RPMfunction((exercise.RPM)); //increases the intensity at the user's input
 
            resetCARDIO = true; //sends signals
            resetHEAT = true;
            resetLUNG = true;
        } //MINI TIMER - TIMES BETWEEN EACH INCREASE IN INTENSITY

        if((moments.ElapsedMilliseconds >= seconds))
        {
            counter++; //every X seconds this increases, and can be used for certain models (blood lactate)
            moments.Restart(); //restarts
            resetCARDIO = true; //sends signals
            resetHEAT = true;
            resetLUNG = true;
            resetGRAPHHR = true;
            resetGRAPHLUNG = true;
        } //INDEPENDENT TIMER - EVERY TEN SECONDS

        if(main.ElapsedMilliseconds >= (limit*1000))
        {
            main.Reset(); //reset is unlike restart in that the timer does not begin again
            mini.Reset();
            moments.Reset();
            counter = 0;
        } //BIG TIMER - TIMES SINCE THE START OF THE 'EXPERIMENT' AND UNTIL THE END

        timer = (mini.ElapsedMilliseconds / 1000); //SECONDS
        elapsed = (main.ElapsedMilliseconds / 1000); //SECONDS
        FPS = (1 / Time.unscaledDeltaTime);
    }

    void Speed()
    {
        //HAVE A BUTTON THAT MAKES THIS TRUE, IT CYCLES BETWEEN DOUBLE SPEED AND NORMAL SPEED
        //IT DOESNT AFFECT UPDATE()
        switch(speedup)
        {
            case 0:
                Time.timeScale = 0.0f; //PAUSE
                break;
            case 1:
                Time.timeScale = 1.0f; //NORMAL SPEED
                break;
            case 2:
                Time.timeScale = 2.0f; //DOUBLE SPEED
                break;
            case 3:
                Time.timeScale = 0.5f; //HALF-SPEED
                break;
            case 4:
                Time.timeScale = 4.0f; //SUPERFAST
                break;
        }
  
    }

    void intervalfunc(float intervalfunc)
    {
        intervals = intervalfunc;
    }

    void increasefunc(float increasefunc)
    {
        increase = increasefunc;
    }

    void limitfunc(float limitfunc)
    {
        limit = limitfunc;
    }
}


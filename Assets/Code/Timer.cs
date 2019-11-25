using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float intervals = 0; //how long between each boost in intensity
    public float increase = 0; //increase RPM by how many (MAYBE CHANGE TO FLAT WORK DONE?)
    public float counter = 0; //how many ten second/s have passed
    public float timer; //time between each loop
    public float elapsed; //total time elapsed
    float limit; //entire experiment runs for X seconds
    public bool recalculateCARDIO = true;
    public Stopwatch mini = new Stopwatch(); //revolves around the player's input
    public Stopwatch main = new Stopwatch(); //measures entire time, and ends the test
    public Stopwatch moments = new Stopwatch(); //every ten seconds, used for loops etc.
    float tenseconds = 10000;
    public bool tensecond = false;

    public bool tensecondCARDIO = false;

    Module exercise;

    // Start is called before the first frame update
    void Start()
    {     
        exercise = GetComponent<Module>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((intervals > 0) && (limit > 0) && (increase > 0) && (mini.IsRunning == false))
        { //if all the correct integers are set, then GO
            //PERHAPS PUT A 'START' BUTTON INSTEAD OF CHECKING MINI?
            main.Start();
            mini.Start();
            moments.Start();
        }

        if(mini.IsRunning && mini.ElapsedMilliseconds == (intervals*1000))
        {         
            mini.Restart();
            exercise.RPMfunction((exercise.RPM + increase));
            recalculateCARDIO = true;
        } //MINI TIMER - TIMES BETWEEN EACH INCREASE IN INTENSITY
               
        if(main.IsRunning && main.ElapsedMilliseconds == (limit*1000))
        {
            main.Reset();
            mini.Reset();
        } //BIG TIMER - TIMES SINCE THE START OF THE 'EXPERIMENT' AND UNTIL THE END

        if(moments.IsRunning && moments.ElapsedMilliseconds == tenseconds)
        {
            counter++;
            moments.Restart();
            tensecond = true;
            tensecondCARDIO = true;

        } //INDEPENDENT TIMER - EVERY TEN SECONDS

        timer = (mini.ElapsedMilliseconds / 1000); //SECONDS
        elapsed = (main.ElapsedMilliseconds / 1000); //SECONDS

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

using System.Collections;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using System.Threading;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float intervals = 0;
    float increase = 0;
    public float counter = 0;
    public float timer;
    float limit;
    public bool recalculate = true;
    public Stopwatch mini = new Stopwatch();
    public Stopwatch main = new Stopwatch();

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
        {
            miniSWF();
            mainSWF();
        }

        if(mini.IsRunning && mini.ElapsedMilliseconds == intervals)
        {
            counter++;
            mini.Restart();
            exercise.RPMfunction((exercise.RPM + increase));
            recalculate = true;
        }

        if(main.IsRunning && main.ElapsedMilliseconds == limit)
        {
            main.Reset();
            mini.Reset();
        }

        timer = mini.ElapsedMilliseconds;

    }

    void intervalsfunc(float intervalfunc)
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

    //this timer is for timing the whole thing
    public void mainSWF()
    {
        main.Start();
    }

    //this timer is for actual timing
    public void miniSWF()
    {
        mini.Start();
    }
}

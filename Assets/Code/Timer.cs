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
    public float elapsed;
    float limit;
    public bool recalculate = true;
    public Stopwatch mini = new Stopwatch();
    public Stopwatch main = new Stopwatch();
    public Stopwatch moments = new Stopwatch();
    float tenseconds = 10000;

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
            main.Start();
            mini.Start();
            moments.Start();
        }

        if(mini.IsRunning && mini.ElapsedMilliseconds == (intervals*1000))
        {         
            mini.Restart();
            exercise.RPMfunction((exercise.RPM + increase));
            recalculate = true;
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
        } //INDEPENDENT TIMER - EVERY TEN SECONDS

        timer = mini.ElapsedMilliseconds;
        elapsed = main.ElapsedMilliseconds;

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
}

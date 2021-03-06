﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    //GENERAL INTS
    public float resistance;
    public float RPM;
    public float efficiency;
    public float speed;
    public string Model = null;
    public float exerciseType;

    //FOR TREADMILLS
    public float treadsetting = 0;
    public float incline;
    public float decline;
    public float MomentSpeed;

    //MAXES
    public float RPMmax;
    public float LoadMax;
    public float WattMax;
    public float inclineMax;
    public float declineMax;
    public float MaxSpeed;

    //OUTP0UT
    public float WorkDone;
    public float BodyWork;
    public float HeatWork;

    Timer timer;
    WaterVapourConversion heat;
    CharacterCustomiser customiser;

    private void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        timer = GetComponent<Timer>();
        customiser = GetComponent<CharacterCustomiser>();
    }

    void Update()
    {
        Workdonefunc();
    }

    void Modulefunc(float model)
    {
        switch (model) //switch based on what type of module theyre using
        {
            case 1f:
                Model = "Treadmill";
                MaxSpeed = 24; //km/h
                inclineMax = 0.25f; //percent
                declineMax = 0.03f; //percent
                exerciseType = 2;
                efficiency = 0.05f;
                break;
            case 2f:
                Model = "Monarch";
                WattMax = 2400;
                RPMmax = 200;
                LoadMax = 12;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 3f:
                Model = "Excalibur";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 25;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 4f:
                Model = "Arm Ergonometer";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 25;
                exerciseType = 4;
                efficiency = 0.15f;
                break;
            case 5f:
                Model = "Rower";
                WattMax = 3000;
                RPMmax = 100;
                LoadMax = 30;
                exerciseType = 3;
                efficiency = 0.25f;
                break;
        }
    }

    //For bikes and rowing, running is entirely different

    void Resfunction(float Resfunc)
    {
        resistance = Resfunc;
        if (resistance > LoadMax)
        {
            resistance = LoadMax;
        };
    }

    public void RPMfunction(float RPMfunc)
    {
        RPM = RPMfunc; //how fast are they going?

        if (RPM > RPMmax)
        {
            RPM = RPMmax;
        };
    }

    public void inclinefunc(float inclinefunc)
    {
        if (treadsetting == 1)
        {
            incline = inclinefunc;
        }
        else if (treadsetting == 2)
        {
            decline = inclinefunc;
        }
    }

    void Workdonefunc()
    {
        //work done (BY THE BODY - lots of energy is lost as heat)
        switch (exerciseType)
        {
            case 1:
                WorkDone = ((RPM / 60) * (resistance * 10)); //watts are /s, rpm is /minute, *10 is for correction?
                break;
            case 2:
                MomentSpeed = ((speed * 1000) / 3600); //gets metres in a single second, then * by force
                WorkDone = (MomentSpeed * (customiser.weight / 3)); //THIS LINE SUCKS DICK, IT'S A COMPLETE GUESS               
                switch (treadsetting) //STILL INSIDE CASE 2, IS THE TREADMILL INCLINED OR DECLINED?  
                {
                    case 0:
                        break;
                    case 1:
                        WorkDone += ((MomentSpeed * incline) * customiser.weight);
                        break;
                    case 2:
                        WorkDone -= ((MomentSpeed * decline) * customiser.weight);
                        break;
                }
                break;
        }

        BodyWork = (WorkDone / efficiency);
        HeatWork = (BodyWork - WorkDone);
    }

    Module() { }
};
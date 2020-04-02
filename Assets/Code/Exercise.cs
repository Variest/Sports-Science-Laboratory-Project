﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    //GENERAL INTS
    public float resistance;
    public float RPM;
    public float efficiency;
    public float speed;
    public string Model = null;
    public int exerciseType; //INT
    public int Module; //INT

    //FOR TREADMILLS
    public int treadsetting = 0; //KEEP THIS AS AN INT
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
    CharacterAvatar customiser;

    private void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        timer = GetComponent<Timer>();
        customiser = GetComponent<CharacterAvatar>();

        //
        Module = 2;
        resistance = 5;
        RPM = 30;
        //
    }

    void Update()
    {
        Modulefunc(Module);
        Workdonefunc();
    }

    void Modulefunc(int model)
    {
        switch (model) //switch based on what type of module theyre using
        {
            case 1:
                Model = "Treadmill";
                MaxSpeed = 24; //km/h
                inclineMax = 0.25f; //percent
                declineMax = 0.03f; //percent
                exerciseType = 2;
                efficiency = 0.05f;
                break;
            case 2:
                Model = "Monarch";
                WattMax = 2400;
                RPMmax = 200;
                LoadMax = 12;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 3:
                Model = "Excalibur";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 25;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 4:
                Model = "Arm Ergonometer";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 25;
                exerciseType = 1;
                efficiency = 0.15f;
                break;
            case 5:
                Model = "Rower";
                WattMax = 3000;
                RPMmax = 100;
                LoadMax = 30;
                exerciseType = 1;
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
            if (incline > inclineMax)
            {
                incline = inclineMax;
            }
        }
        else if (treadsetting == 2)
        {
            decline = -inclinefunc;
            if (decline < declineMax)
            {
                decline = declineMax;
            }
        }
    }

    void Workdonefunc()
    {
        //work done (BY THE BODY - lots of energy is lost as heat)
        switch (exerciseType)
        {
            case 1:
                WorkDone = ((RPM / 60) * (resistance * 10)); //watts are /s, rpm is /minute, *10 is for correction
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
}
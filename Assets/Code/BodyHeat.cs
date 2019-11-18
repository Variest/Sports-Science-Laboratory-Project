﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeat : MonoBehaviour
{
    public float BodyTemp = 36.0f;
    public float BodyWaterBase;
    public float BodyWater;
    public float WaterDrunk = 1000; //DEFAULTS TO 1 LITRE, which is a normal amount
    public float WaterPrcnt;
    public float SweatRate = 1000;
    public float SweatPower = 2400; //JOULES PER G (ML) OF SWEAT
    public float CoolPower;
    public float humidity = 30; //percent
    public float HeatGain;

    Module exercise; //use heatwork and workdone
    WaterVapourConversion heat; //gastemp is what you want!
    Timer time;
    CharacterCustomiser customiser;


    // Start is called before the first frame update
    void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        exercise = GetComponent<Module>();
        time = GetComponent<Timer>();
        customiser = GetComponent<CharacterCustomiser>();
    }

    // Update is called once per frame
    void Update()
    {
        if (time.tensecond)
        {
            sweatfunc();
            bodyheatfunc();
            time.tensecond = false;
        }

        if(BodyTemp >= 37.0f)
        {          
            if(BodyTemp >= 38.0f)
            {
                if(BodyTemp >= 39.0f)
                {
                    if(BodyTemp >= 40.0f)
                    {
                        //DEAD
                    }
                    //PROBABLY UNCONSCIOUS
                    SweatRate = 4000;
                }
                //WOOZY, EXTREMELY SWEATY
                SweatRate = 3000;
            }
            //SWEATY BOY
            SweatRate = 1500;
        }
        

        WaterPrcnt = (BodyWater / BodyWaterBase);

        if(WaterPrcnt <= 0.97f)
        {
            if(WaterPrcnt <= 0.93f)
            {                
                if(WaterPrcnt <= 0.9)
                {                    
                    if(WaterPrcnt <= 0.8)
                    {
                        //DEAD
                    }
                    //DANGEROUSLY EXHAUSTED
                }
                //DIZZY, SERIOUSLY TIRED
            }
            //A BIT TIRED
        }
        
    }

    void bodyheatfunc()
    {
        HeatGain = exercise.HeatWork - CoolPower;
    }

    void sweatfunc()
    {
        CoolPower = ((SweatRate/3600) * SweatPower); //this is how much heat (in watts) is lost as sweat per second

        if (humidity >= 60)
        {
            if (humidity >= 70)
            {
                if (humidity >= 80)
                {
                    if (humidity >= 90)
                    {
                        if (humidity >= 100)
                        {
                            CoolPower *= 0.1f;
                        }
                        CoolPower *= 0.2f;
                    }
                    CoolPower *= 0.3f;
                }
                CoolPower *= 0.5f;
            }
            CoolPower *= 0.8f;
        }
                
        BodyWater -= (SweatRate / 360); //divide by 3600 for seconds, and times by 10, making 360
    }

    void waterdrinkfunc(float waterdrink)  //how much water they have drunk before the test, defaults to a litre
    {
        WaterDrunk = waterdrink;
    }

    void bodywaterfunc()
    {
        if (customiser.gender == true)
        {
            BodyWater = ((customiser.weight * 0.60f) * 1000); //in millilitres
        }
        else
        {
            BodyWater = ((customiser.weight * 0.55f) * 1000);
        }
                
        BodyWaterBase = BodyWater;
        BodyWater += WaterDrunk;
    }
}

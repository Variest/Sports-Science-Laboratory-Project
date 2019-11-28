using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeat : MonoBehaviour
{ 
    BodyHeat(){ }


    public float BodyTemp = 36.0f;
    public float BodyWaterBase;
    public float BodyWater;
    public float WaterDrunk = 1000; //DEFAULTS TO 1 LITRE, which is a normal amount
    public float WaterPrcnt;
    public float SweatRate;
    public float MaxSweatRate = 1000; //PER HOUR (3600 seconds)
    public float SweatPower = 2400; //JOULES PER G (ML) OF SWEAT
    public float CoolPower;
    public float humidity = 30; //percent
    public float HeatGain;
    public float metabolism = 85; //HUMAN METABOLISM TAKES 85W POWER CONSTANTLY
    public float HeatCapacity = 0.83f;
    public float KCAL = 4184; //4184 joules = 1KCAL

    public float WaterCond = 0;
    public float HeatCond = 0;

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
    }

    void bodyheatfunc()
    {
        HeatGain = (exercise.HeatWork + metabolism) - CoolPower;
        if (HeatGain > 0)
        {
            BodyTemp += (((HeatGain / KCAL) / customiser.weight) * (HeatCapacity * 10));
            //body temperature rise = how many KCAL's gained in heat energy/weight * HC coefficient (ten seconds)
            //if the temperature actually rises, check if it rose in a bad way

            if (BodyTemp >= 37.0f)
            {
                //GETTING TIRED/SWEATY
                MaxSweatRate = 1500;
                HeatCond = 0;

                if (BodyTemp >= 38.0f)
                {
                    //WOOZY, VERY SWEATY
                    MaxSweatRate = 3000;
                    HeatCond = 1;

                    if (BodyTemp >= 39.0f)
                    {
                        //PROBABLY UNCONSCIOUS
                        MaxSweatRate = 4000;
                        HeatCond = 2;

                        if (BodyTemp >= 40.0f)
                        {
                            //DEAD
                            HeatCond = 3;
                        }
                    }
                }
            }
        }
    }

    void sweatfunc()
    {
        SweatRate = ((exercise.HeatWork + metabolism) / SweatPower); //this is HOW MANY MLs ARE NEEDED A SECOND
        if((SweatRate * 3600) > MaxSweatRate)
        {
            SweatRate = MaxSweatRate;
        }

        CoolPower = (SweatRate * SweatPower); //this is how much heat (in watts) is lost as sweat per second

        if (humidity >= 60)
        {
            CoolPower *= 0.8f;

            if (humidity >= 70)
            {
                CoolPower *= 0.5f;

                if (humidity >= 80)
                {
                    CoolPower *= 0.3f;

                    if (humidity >= 90)
                    {
                        CoolPower *= 0.2f;

                        if (humidity >= 100)
                        {
                            CoolPower *= 0.1f;
                        }
                    }
                }
            }
        }
                
        BodyWater -= (SweatRate * 10); //this is calculated every ten seconds, so *10 
        //EXPERIMENT WITH TURNING * 10 TO * 100 FOR INCREASED OUTPUT
        //CHECKING BODYWATER NOW THAT IT IS DECREASED

        WaterPrcnt = (BodyWater / BodyWaterBase);

        if(WaterPrcnt <= 0.97f)
        {   
            //A BIT TIRED/THIRSTY
            MaxSweatRate *= 0.9f;
            WaterCond = 1;

            if(WaterPrcnt <= 0.93f)
            {  
                //DIZZY, SERIOUSLY TIRED
                MaxSweatRate *= 0.8f;
                WaterCond = 2;   
                
                if(WaterPrcnt <= 0.9)
                {   
                    //DANGEROUSLY EXHAUSTED
                    MaxSweatRate *= 0.6f;
                    WaterCond = 3;   
                    
                    if(WaterPrcnt <= 0.8)
                    {
                        //DEAD
                        MaxSweatRate *= 0.5f;
                        WaterCond = 4;
                    }
                }
            }
        }    
    }

    void waterdrinkfunc(float waterdrink)  //how much water they have drunk before the test, defaults to a litre
    {
        WaterDrunk = waterdrink;
    }

    void bodywaterfunc()
    {
        if (customiser.gender == 1)
        {
            BodyWater = ((customiser.weight * 0.60f) * 1000); //in millilitres
        }
        else if(customiser.gender == 0)
        {
            BodyWater = ((customiser.weight * 0.55f) * 1000);
        }
                
        BodyWaterBase = BodyWater;
        BodyWater += WaterDrunk;
    }
}

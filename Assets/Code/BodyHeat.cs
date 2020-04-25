using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeat : MonoBehaviour
{ 
    BodyHeat(){ }

    //WATER
    public float bodyWaterBase;
    public float waterDrunk = 1000; //DEFAULTS TO 1 LITRE, which is a normal amount

    //SWEAT
    public float sweatRate;
    public float maxSweatRate = 1000; //PER HOUR (3600 seconds)
    public float sweatPower = 2400; //JOULES PER G (ML) OF SWEAT
    public float sweatReserves = 1.0f;
    public float coolPower;
    
    //HEAT
    public float humidity = 30; //percent
    public float heatGain;
    public float heatCapacity = 0.83f;
    public float kcal = 4184; //4184 joules = 1KCAL
    public float metabolism = 85; //HUMAN METABOLISM TAKES 85W POWER CONSTANTLY

    public float heatDiff = 0;
    public float airHC = 1.005f;
    public float airHeat = 0;

    //OUTPUT
    public float waterCond = 0;
    public float heatCond = 0;

    Exercise exercise; //use heatwork and workdone
    WaterVapourConversion heat; //gastemp is what you want!
    Timer time;
    CharacterAvatar avatar;


    // Start is called before the first frame update
    void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        exercise = GetComponent<Exercise>();
        time = GetComponent<Timer>();
        avatar = GetComponent<CharacterAvatar>();
        BodyWaterfunc();

        avatar.BodyTemp = 36.0f;

    }

    // Update is called once per frame
    void Update()
    {
        if(time.resetHEAT == true)
        {
            sweatfunc();
            airtempfunc();
            bodyheatfunc();
            time.resetHEAT = false;
        }    
    }

    void bodyheatfunc()
    {
        heatGain = ((exercise.heatWork + metabolism) - coolPower + airHeat);
        if (heatGain > 0)
        {
            avatar.BodyTemp += (((heatGain / kcal) / avatar.weight) * (heatCapacity * 10));
            //body temperature rise = how many KCAL's gained in heat energy/weight * HC coefficient (ten seconds)
            //if the temperature actually rises, check if it rose in a bad way

            if (avatar.BodyTemp >= 37.0f)
            {
                //GETTING TIRED/SWEATY
                maxSweatRate = 1000;
                heatCond = 0;

                if (avatar.BodyTemp >= 38.0f)
                {
                    //WOOZY, VERY SWEATY
                    maxSweatRate = 2000;
                    heatCond = 1;

                    if (avatar.BodyTemp >= 39.0f)
                    {
                        //PROBABLY UNCONSCIOUS
                        maxSweatRate = 3000;
                        heatCond = 2;

                        if (avatar.BodyTemp >= 40.0f)
                        {
                            //DEAD
                            heatCond = 3;
                        }
                    }
                }
            }
        }
    }

    void airtempfunc()
    {
        if (heat.gasTemp > 0)
        {
            heatDiff = (heat.gasTemp - avatar.BodyTemp);
            airHeat = ((exercise.heatWork * 0.15f) + (heatDiff * airHC));
        }
    }

    void sweatfunc()
    {
        sweatRate = (((exercise.heatWork*0.85f) + metabolism) / sweatPower); //this is HOW MANY MLs ARE NEEDED A SECOND
        if((sweatRate * 3600) > maxSweatRate) //makes sure it isnt too much
        {
            sweatRate = maxSweatRate;
        }

        sweatRate *= sweatReserves; //sweatreserves is 'how much the body is able to sweat' - decreases with water content

        coolPower = (sweatRate * sweatPower); //this is how much heat (in watts) is lost as sweat per second

        if (humidity >= 60 && humidity < 70 )
        {
            coolPower *= 0.8f;

        }
        else if (humidity >= 70 && humidity < 80)
        {
            coolPower *= 0.5f;
        }
        else if (humidity >= 80 && humidity < 100)
        {
            coolPower *= 0.3f;
        }
        else if (humidity >= 100)
        {
            coolPower *= 0.1f;
        }

        avatar.BodyWater -= (sweatRate * 10); //this is calculated every ten seconds, so *10 
        //EXPERIMENT WITH TURNING * 10 TO * 100 FOR INCREASED OUTPUT
        //CHECKING customiser.BodyWater NOW THAT IT IS DECREASED

        avatar.WaterPrcnt = (avatar.BodyWater / bodyWaterBase);

        if(avatar.WaterPrcnt <= 0.97f && avatar.WaterPrcnt > 0.93f)
        {   
            //A BIT TIRED/THIRSTY
            sweatReserves = 0.9f;
            waterCond = 1;

        } 
        else if(avatar.WaterPrcnt <= 0.93f && avatar.WaterPrcnt > 0.9)
        {
            sweatReserves = 0.8f;
            waterCond = 2;
        }
        else if (avatar.WaterPrcnt <= 0.9f && avatar.WaterPrcnt > 0.8)
        {
            sweatReserves = 0.6f;
            waterCond = 3;
        }
        else if (avatar.WaterPrcnt <= 0.8)
        {
            sweatReserves = 0.5f;
            waterCond = 4;
        }
    }

    void waterdrinkfunc(float waterdrink)  //how much water they have drunk before the test, defaults to a litre
    {
        waterDrunk = waterdrink;
    }

    void BodyWaterfunc()
    {
        switch (avatar.gender)
        {
            case 1:
                avatar.BodyWater = ((avatar.weight * 0.60f) * 1000); //in millilitres - a man's body is 60% water
                break;
            case 0:
                avatar.BodyWater = ((avatar.weight * 0.55f) * 1000); //a woman's body is 55% water
                break;
            default:
                avatar.BodyWater = ((avatar.weight * 0.60f) * 1000);
                break;
    }
        bodyWaterBase = avatar.BodyWater;
        avatar.BodyWater += waterDrunk;
    }
}
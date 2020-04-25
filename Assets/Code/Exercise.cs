using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise : MonoBehaviour
{
    //GENERAL INTS
    public float resistance;
    public float rpm;
    public float efficiency;
    public float speed;
    public string model = null;
    public int exerciseType; //INT
    public int module; //INT

    //FOR TREADMILLS
    public int treadSetting = 0; //KEEP THIS AS AN INT
    public float incline;
    public float decline;
    public float momentSpeed;

    //MAXES
    public float rpmMax;
    public float loadMax;
    public float wattMax;
    public float inclineMax;
    public float declineMax;
    public float maxSpeed;

    //OUTP0UT
    public float workDone;
    public float bodyWork;
    public float heatWork;

  //  Timer timer;
    //WaterVapourConversion heat; //never seems to be useed?
    CharacterAvatar customiser;

    private void Start()
    {
       // heat = GetComponent<WaterVapourConversion>();
       // timer = GetComponent<Timer>();
        customiser = GetComponent<CharacterAvatar>();

        //

        //
    }

    void Update()
    {

        //ModuleFunction(module);
        //workDonefunc();

    }

    void ModuleFunction(int modelNumber)
    {
        switch (modelNumber) //switch based on what type of module theyre using
        {
            case 1:
                model = "Treadmill";
                maxSpeed = 24; //km/h
                inclineMax = 0.25f; //percent
                declineMax = 0.03f; //percent
                exerciseType = 2;
                efficiency = 0.05f;
                break;
            case 2:
                model = "Monarch";
                wattMax = 2400;
                rpmMax = 200;
                loadMax = 12;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 3:
                model = "Excalibur";
                wattMax = 3000;
                rpmMax = 180;
                loadMax = 25;
                exerciseType = 1;
                efficiency = 0.2f;
                break;
            case 4:
                model = "Arm Ergonometer";
                wattMax = 3000;
                rpmMax = 180;
                loadMax = 25;
                exerciseType = 1;
                efficiency = 0.15f;
                break;
            case 5:
                model = "Rower";
                wattMax = 3000;
                rpmMax = 100;
                loadMax = 30;
                exerciseType = 1;
                efficiency = 0.25f;
                break;
        }
    }

    //For bikes and rowing, running is entirely different

    void Resfunction(float Resfunc)
    {
        resistance = Resfunc;
        if (resistance > loadMax)
        {
            resistance = loadMax;
        };
    }

    public void rpmFunction(float rpmFunc)
    {
        rpm = rpmFunc; //how fast are they going?

        if (rpm > rpmMax)
        {
            rpm = rpmMax;
        };
    }

    public void InclineFunction(float inclinefunc)
    {
        if (treadSetting == 1)
        {
            incline = inclinefunc;
            if (incline > inclineMax)
            {
                incline = inclineMax;
            }
        }
        else if (treadSetting == 2)
        {
            decline = -inclinefunc;
            if (decline < declineMax)
            {
                decline = declineMax;
            }
        }
    }

    void WorkDoneFunction()
    {
        //work done (BY THE BODY - lots of energy is lost as heat)
        switch (exerciseType)
        {
            case 1:
                workDone = ((rpm / 60) * (resistance * 10)); //watts are /s, rpm is /minute, *10 is for correction
                break;
            case 2:
                momentSpeed = ((speed * 1000) / 3600); //gets metres in a single second, then * by force
                workDone = (momentSpeed * (customiser.weight / 3)); //THIS LINE SUCKS DICK, IT'S A COMPLETE GUESS               
                switch (treadSetting) //STILL INSIDE CASE 2, IS THE TREADMILL INCLINED OR DECLINED?  
                {
                    case 0:
                        break;
                    case 1:
                        workDone += ((momentSpeed * incline) * customiser.weight);
                        break;
                    case 2:
                        workDone -= ((momentSpeed * decline) * customiser.weight);
                        break;
                }
                break;
        }

        bodyWork = (workDone / efficiency);
        heatWork = (bodyWork - workDone);
    }

    public void ManualUpdate() //the same as the update would do, but we can call it ourselves
    {
        WorkDoneFunction();
    }
}
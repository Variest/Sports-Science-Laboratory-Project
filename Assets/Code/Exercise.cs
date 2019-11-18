using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{

    public float resistance;
    public float RPM;
    public float RPMmax;
    public float LoadMax;
    public float WattMax;
    public float inclineMax;
    public float declineMax;
    public float efficiency;
    public float speed;
    public float MaxSpeed;
    public string Model = null;
    public string exerciseType = null;

    public float WorkDone;
    public float BodyWork;
    public float HeatWork;

    Timer timer;
    WaterVapourConversion heat;
    private void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        timer = GetComponent<Timer>();
    }

    void Update()
    {    
        Workdonefunc();
    }

    Module(float model)
    {
        switch (model) //switch based on what type of module theyre using
        {
            case 1f: //MORE INFO NEEDED
                Model = "Treadmill"; 
                MaxSpeed = 24;
                inclineMax = 25; //percent
                declineMax = 3; //percent
                exerciseType = "Running";
                efficiency = 0.15f;
                break;
            case 2f:
                Model = "Monarch";
                WattMax = 2400;
                RPMmax = 200;
                LoadMax = 12;
                exerciseType = "Cycling";
                efficiency = 0.3f;
                break;
            case 3f:
                Model = "Excalibur";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 15;
                exerciseType = "Cycling";
                efficiency = 0.3f;
                break;
            case 4f:
                Model = "Arm Ergonometer";
                WattMax = 3000;
                RPMmax = 180;
                LoadMax = 15;
                exerciseType = "Arm Rowing";
                efficiency = 0.2f;
                break;
            case 5f: //MORE INFO NEEDED
                Model = "Rower";
                WattMax = 3000;
                RPMmax = 100;
                LoadMax = 30;
                exerciseType = "Rowing";
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

    void Workdonefunc()
    {
        //work done (BY THE BODY - lots of energy is lost as heat)
        WorkDone = ((RPM / 60) * resistance); //watts are /s, rpm is /minute
        BodyWork = (WorkDone / efficiency);
        HeatWork = (BodyWork - WorkDone);

    }


};
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public float WorkDone;
    public float resistance;
    public float RPM;
    public float RPMmax;
    public float LoadMax;
    public float WattMax;
    public float inclineMax;
    public float declineMax;
    public float speed;
    public float MaxSpeed;
    public string Model = null;
    public string exerciseType = null;
    public float efficiency;

    Timer timer;
    private void Start()
    {
        timer = GetComponent<Timer>();
    }

    Module(float model)
    {
        switch (model) //switch based on what type of module theyre using
        {
            case 1f: //MORE INFO NEEDED
                Model = "Treadmill"; 
                MaxSpeed = 24;
                inclineMax = 25;
                declineMax = 3;
                exerciseType = "Running";
                efficiency = 0.25f;
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
                break;
            case 5f: //MORE INFO NEEDED
                Model = "Rower";
                RPMmax = 100;
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
        WorkDone = (((RPM * resistance) / efficiency) / 60); //watts are /s
    }

    void Update()
    {    
        Workdonefunc();
    }
};
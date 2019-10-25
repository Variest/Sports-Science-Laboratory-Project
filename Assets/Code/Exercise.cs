using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public float WorkDone;
    float resistance;
    float RPM;
    float RPMmax;
    float LoadMax;
    float WattMax;
    float inclineMax;
    float declineMax;
    float speed;
    float MaxSpeed;
    string Model = null;
    string exerciseType = null;
    float efficiency;

    Module(float model) {
        switch (model)
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


    //FOR THE BIKES and rowing i guess? hmhmhmhm.....

    void Resfunction(float Resfunc)
    {
        resistance = Resfunc;
        if (resistance > LoadMax)
        {
            resistance = LoadMax;
        };
    }

    void RPMfunction(float RPMfunc)
    {
        RPM = RPMfunc;

        if (RPM > RPMmax)
        {
            RPM = RPMmax;
        };
    }

    void Workdonefunc()
    {
        WorkDone = ((RPM * resistance) / efficiency) / 60f; //CYCLING IS 30% EFFICIENT watts are /s
    }

};
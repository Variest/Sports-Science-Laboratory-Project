using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bike : MonoBehaviour
{
    public float WorkDone;
    float resistance;
    float RPM;
    float RPMmax = 200;
    float LoadMax = 12;
    float WattMax = 2400;

    Bike() { }

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
        WorkDone = (RPM * resistance) / 0.3f; //CYCLING IS 30% EFFICIENT
    }

};
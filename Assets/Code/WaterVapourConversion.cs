using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVapourConversion : MonoBehaviour
{
    float waterVapour = 0;
    public float gasTemp = 0;
    // Start is called before the first frame update

    void gastempfunc(float gasfunc)
    {
        gasTemp = gasfunc;
        WVfunc();
    }

    // Update is called once per frame
    void WVfunc()
    {
        switch (gasTemp)
        {
            case 16:
                waterVapour = 13.6f;
                break;
            case 17:
                waterVapour = 14.5f;
                break;
            case 18:
                waterVapour = 15.48f;
                break;
            case 18.5f:
                waterVapour = 15.97f;
                break;
            case 19:
                waterVapour = 16.48f;
                break;
            case 19.5f:
                waterVapour = 17f;
                break;
            case 20:
                waterVapour = 17.54f;
                break;
            case 20.5f:
                waterVapour = 18.08f;
                break;
            case 21:
                waterVapour = 18.65f;
                break;
            case 21.5f:
                waterVapour = 19.52f;
                break;
            case 22:
                waterVapour = 19.83f;
                break;
            case 22.5f:
                waterVapour = 20.44f;
                break;
            case 23:
                waterVapour = 21.09f;
                break;
            case 23.5f:
                waterVapour = 21.71f;
                break;
            case 24:
                waterVapour = 22.38f;
                break;
            case 24.5f:
                waterVapour = 23.06f;
                break;
            case 25:
                waterVapour = 23.76f;
                break;
            case 25.5f:
                waterVapour = 24.47f;
                break;
            case 26:
                waterVapour = 25.21f;
                break;
            case 26.5f:
                waterVapour = 25.96f;
                break;
            case 27:
                waterVapour = 26.74f;
                break;
            case 27.5f:
                waterVapour = 27.54f;
                break;
            case 28:
                waterVapour = 28.35f;
                break;
            case 28.5f:
                waterVapour = 29.18f;
                break;
            case 29:
                waterVapour = 30.04f;
                break;
            case 29.5f:
                waterVapour = 30.92f;
                break;
            case 30:
                waterVapour = 31.82f;
                break;
            case 37:
                waterVapour = 47f;
                break;
            default:
                waterVapour = 0;
                break;
        }
                
    }
}

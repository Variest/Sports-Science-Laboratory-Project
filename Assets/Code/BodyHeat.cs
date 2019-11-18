using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeat : MonoBehaviour
{
    public float BodyTemp = 36.0f;
    public float BodyWaterBase;
    public float BodyWater;
    public float WaterDrunk = 1000; //DEFAULTS TO 1 LITRE, which is a normal amount
    public float WaterPrcnt;

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
                }
                //WOOZY, EXTREMELY SWEATY
            }
            //SWEATY BOY
        }
        //WORKING HARD

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

    }

    void sweatfunc()
    {

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

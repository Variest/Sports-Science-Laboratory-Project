using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyHeat : MonoBehaviour
{
    public float BodyTemp = 36.0f;

    Module exercise; //use heatwork and workdone
    WaterVapourConversion heat; //gastemp is what you want!
    Timer time;


    // Start is called before the first frame update
    void Start()
    {
        heat = GetComponent<WaterVapourConversion>();
        exercise = GetComponent<Module>();
        time = GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Output : MonoBehaviour
{
    Cardio cardio;
    //HEART RATE(0-1) AND BLOOD LACTATE(0-4)
    //PAINED FACE, AND TIRED LOOKING
    BodyHeat heat;
    //HEAT(0-3) AND WATER CONTENT (0-4)
    //HOT AND SWEATY AND THIRSTY
    Timer timer;
    Module exercise;

    public string HR;
    public string Bla;
    public string Heat;
    public string Water;

    // Start is called before the first frame update
    void Start()
    {
        cardio = GetComponent<Cardio>();
        heat = GetComponent<BodyHeat>();
        timer = GetComponent<Timer>();
        exercise = GetComponent<Module>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (cardio.HRCond)
        {
            case 0:
                HR = "Heart Rate Normal"; //anything below max
                break;
            case 1:
                HR = "Heart Rate High"; //max or above
                break;
        }

        switch (cardio.BlaCond)
        {
            case 0:
                Bla = "Blood Lactate Normal"; //1-4
                break;
            case 1:
                Bla = "Blood Lactate Rising"; //5-9
                break;
            case 2:
                Bla = "Blood Lactate Moderate"; //10-14
                break;
            case 3:
                Bla = "Blood Lactate High"; //15-19
                break;
            case 4:
                Bla = "Blood Lactate Dangerous"; //20+
                break;
        }

        switch(heat.HeatCond)
        {
            case 0:
                Heat = "Heat Normal"; //37 degrees
                break;
            case 1:
                Heat = "Heat Rising"; //38 degrees
                break;
            case 2:
                Heat = "Heat High"; //39 degrees
                break;
            case 3:
                Heat = "Heat Dangerous"; //40 degrees
                break;
        }

        switch(heat.WaterCond)
        {
            case 0:
                Water = "Water Normal"; //100% water percent+
                break;
            case 1:
                Water = "Water Falling"; //97% about
                break;
            case 2:
                Water = "Water Moderate"; //93%
                break;
            case 3:
                Water = "Water Low"; //90%
                break;
            case 4:
                Water = "Water Dangerous"; //80%
                break;
        }

    }
}

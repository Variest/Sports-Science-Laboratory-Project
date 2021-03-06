﻿using System.Collections;
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
    Exercise exercise;
    GraphScriptHR graph;

    public string HR;
    public string Bla;
    public string Heat;
    public string Water;
    public string Exercise;

    // Start is called before the first frame update
    public void Start()
    {
        cardio = GetComponent<Cardio>();
        graph = GetComponent<GraphScriptHR>();
        heat = GetComponent<BodyHeat>();
        timer = GetComponent<Timer>();
        exercise = GetComponent<Exercise>();
    }

    // Update is called once per frame
    public void Update()
    {
        switch (cardio.HRCond)
        {
            case 0:
                HR = "Heart Rate Normal"; //anything below lactate threshhold
                break;
            case 1:
                HR = "Heart Rate High"; //LT or above
                break;
            default:
                HR = "Heart Rate Normal"; //anything below lactate threshhold
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
            default:
                Bla = "Blood Lactate Normal"; //1-4
                break;
        }

        switch(heat.heatCond)
        {
            case 0:
                Heat = "Body Heat Normal"; //37 degrees
                break;
            case 1:
                Heat = "Body Heat Rising"; //38 degrees
                break;
            case 2:
                Heat = "Body Heat High"; //39 degrees
                break;
            case 3:
                Heat = "Body Heat Dangerous"; //40 degrees
                break;
            default:
                Heat = "Body Heat Normal"; //37 degrees
                break;
        }

        switch(heat.waterCond)
        {
            case 0:
                Water = "Body Water Content Normal"; //100% water percent+
                break;
            case 1:
                Water = "Body Water Content Falling"; //97% about
                break;
            case 2:
                Water = "Body Water Content Moderate"; //93%
                break;
            case 3:
                Water = "Body Water Content Low"; //90%
                break;
            case 4:
                Water = "Body Water Content Dangerous"; //80%
                break;
            default:
                Water = "Body Water Content Normal"; //100% water percent+
                break;
        }

        switch (exercise.exerciseType)
        {

            case 1:
                Exercise = "Cycling";
                break;
            case 2:
                Exercise = "Running";
                break;
            case 3:
                Exercise = "Rowing";
                break;
            case 4:
                Exercise = "Arm Ergonometer";
                break;
        }
    }
}
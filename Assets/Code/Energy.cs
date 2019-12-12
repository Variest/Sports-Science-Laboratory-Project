using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ENERGY EXPENDITURE
public class Energy : MonoBehaviour
{
    float CE; //calorific equivalent of 02
    public float EE; //energy expenditure
    public float ME; //mechanical efficency

    pvEquations vents;
    Module exercise;
    void Start()
    {
        vents = GetComponent<pvEquations>();
        exercise = GetComponent<Module>();
    }

    void MEfunc()
    {
        ME = (exercise.efficiency * 100);
    }

    void CEfunction() //changes the calorific equivalent of air depending on respiratory quotient
    {
        switch (vents.RQ)
        {
            case 0.707f:
                CE = 4.686f;
                break;
            case 0.71f:
                CE = 4.69f;
                break;
            case 0.72f:
                CE = 4.702f;
                break;
            case 0.73f:
                CE = 4.714f;
                break;
            case 0.74f:
                CE = 4.727f;
                break;
            case 0.75f:
                CE = 4.739f;
                break;
            case 0.76f:
                CE = 4.75f;
                break;
            case 0.77f:
                CE = 4.764f;
                break;
            case 0.78f:
                CE = 4.776f;
                break;
            case 0.79f:
                CE = 4.788f;
                break;
            case 0.80f:
                CE = 4.801f;
                break;
            case 0.81f:
                CE = 4.813f;
                break;
            case 0.82f:
                CE = 4.825f;
                break;
            case 0.83f:
                CE = 4.838f;
                break;
            case 0.84f:
                CE = 4.85f;
                break;
            case 0.85f:
                CE = 4.862f;
                break;
            case 0.86f:
                CE = 4.875f;
                break;
            case 0.87f:
                CE = 4.887f;
                break;
            case 0.88f:
                CE = 4.899f;
                break;
            case 0.89f:
                CE = 4.911f;
                break;
            case 0.90f:
                CE = 4.924f;
                break;
            case 0.91f:
                CE = 4.936f;
                break;
            case 0.92f:
                CE = 4.948f;
                break;
            case 0.93f:
                CE = 4.961f;
                break;
            case 0.94f:
                CE = 4.973f;
                break;
            case 0.95f:
                CE = 4.985f;
                break;
            case 0.96f:
                CE = 4.998f;
                break;
            case 0.97f:
                CE = 5.01f;
                break;
            case 0.98f:
                CE = 5.022f;
                break;
            case 0.99f:
                CE = 5.035f;
                break;
            case 1.0f:
                CE = 5.047f;
                break;
        }

        EEfunction(); //is called after this changes to make sure it doesnt miss anything
    }

    void EEfunction()
    {
        EE = (vents.VO2 * CE);
    }

    Energy(){}
};